using AxisEngine.Core.Assets;
using AxisEngine.Core.Assets.Abstractions;
using System.Text.Json;

namespace AxisEngine.Assets
{
    public class AssetManager : IAssetManager
    {
        private readonly Dictionary<Type, IAssetDatabase> _assetDatabases;
        private readonly Dictionary<Guid, AssetStatus> _assetsStatus;
        private readonly Dictionary<Guid, MetaData> _metaDatas;

        private IAssetLoadingQueue _assetLoadingQueue;

        private readonly JsonSerializerOptions _metaDataSerializeOptions;

        private string _baseAssetFolder;

        public AssetManager(string baseAssetFolder)
        {
            _baseAssetFolder = baseAssetFolder;

            _assetDatabases = new Dictionary<Type, IAssetDatabase>();
            _assetsStatus = new Dictionary<Guid, AssetStatus>();
            _metaDatas = new Dictionary<Guid, MetaData>();

            _metaDataSerializeOptions = new JsonSerializerOptions()
            {
                IncludeFields = true,
                WriteIndented = true,
            };
        }

        private IAssetDatabase<T> GetOrCreateAssetDatabase<T>() where T : struct, IAsset
        {
            var type = typeof(T);

            if (_assetDatabases.TryGetValue(type, out var assetDatabase))
                return (IAssetDatabase<T>)assetDatabase;

            var newAssetDatabase = new AssetDatabase<T>();

            _assetDatabases.Add(type, newAssetDatabase);

            return newAssetDatabase;
        }

        public void CreateAssetDatabase<T>() where T : struct, IAsset
        {
            var type = typeof(T);

            if (_assetDatabases.ContainsKey(type))
                return;

            var newAssetDatabase = new AssetDatabase<T>();

            _assetDatabases.Add(type, newAssetDatabase);
        }

        private IAssetDatabase<T> GetAssetDatabase<T>() where T : struct, IAsset
        {

            return _assetDatabases.TryGetValue(typeof(T), out var assetDatabase) ? (IAssetDatabase<T>)assetDatabase : throw new KeyNotFoundException($"AssetDatabas from the type {typeof(T)} not found.");
        }

        private IAssetDatabase GetAssetDatabase(Type type)
        {
            return _assetDatabases.TryGetValue(type, out var assetDatabase) ? assetDatabase : throw new KeyNotFoundException($"AssetDatabas from the type {type} not found.");
        }

        private void SaveMetaData(string path, MetaData metaData)
        {
            string json = JsonSerializer.Serialize(metaData, _metaDataSerializeOptions);

            File.WriteAllText(path, json);
        }

        public void SetLoadingQueue(IAssetLoadingQueue assetLoadingQueue)
        {
            _assetLoadingQueue = assetLoadingQueue;
        }

        public (AssetStatus, T?) GetAsset<T>(Guid id) where T : struct, IAsset
        {
            var assetStatus = GetAssetStatus(id);

            if(assetStatus == AssetStatus.Loading)
                return (AssetStatus.Loading, null);

            if(assetStatus == AssetStatus.Failed)
                return (AssetStatus.Failed, null);

            if (assetStatus == AssetStatus.Ready)
                return (assetStatus, GetAssetDatabase<T>().GetAsset(id));

            var metaData = GetMetaData(id);

            CreateAssetDatabase<T>();

            _assetLoadingQueue.AddToQueue(typeof(T), metaData);

            return (AssetStatus.Loading, null);
        }

        public AssetStatus GetAssetStatus(Guid id)
        {
            if (_assetsStatus.TryGetValue(id, out var assetStatus))
                return assetStatus;

            _assetsStatus.Add(id, AssetStatus.NotLoad);

            return AssetStatus.NotLoad;
        }

        public void RegisterAsset(Type type, IAsset asset)
        {
            if (asset == null)
                throw new Exception();

            GetAssetDatabase(type).AddAsset(asset);

            var metaData = new MetaData(asset.Id, asset.Name, asset.FilePath, asset.Data);

            _metaDatas[asset.Id] = metaData;

            string name = Path.GetFileNameWithoutExtension(asset.FilePath);
            string? path = Path.GetDirectoryName(asset.FilePath);

            if (string.IsNullOrEmpty(path))
                throw new Exception("Relative path to meta directory is null or empty.");

            string metaPath = $"{path}\\{name}.meta";

            SaveMetaData(metaPath, metaData);

            _assetsStatus[asset.Id] = AssetStatus.Ready;
        }

        public bool HasAsset(Guid id)
        {
            foreach(var assetDatabase in _assetDatabases.Values)
            {
                if (assetDatabase.HasAsset(id))
                    return true;
            }

            return false;
        }

        public bool HasAsset<T>() where T : struct, IAsset
        {
            return _assetDatabases.ContainsKey(typeof(T));
        }

        public bool HasAsset<T>(Guid id) where T : struct, IAsset
        {
            return _assetDatabases.TryGetValue(typeof(T), out var assetDatabase) ? assetDatabase.HasAsset(id) : false;
        }

        public void LoadAllMetaData()
        {
            var excludedExtensions = new[] { ".tmp", ".log", ".meta" };

            var assetsPath = Directory.GetFiles(_baseAssetFolder, "*.*", SearchOption.AllDirectories)
                .Where(file =>
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (excludedExtensions.Contains(ext)) return false;

                    return true;
                })
                .ToArray();

            foreach (var assetPath in assetsPath)
            {
                string name = Path.GetFileNameWithoutExtension(assetPath);
                string? path = Path.GetDirectoryName(assetPath);

                if (string.IsNullOrEmpty(path))
                    throw new Exception("Relative path to meta directory is null or empty.");

                string metaPath = $"{path}\\{name}.meta";

                if (File.Exists(metaPath))
                {
                    var jsonMeta = File.ReadAllText(metaPath);

                    var metaData = JsonSerializer.Deserialize<MetaData>(jsonMeta, _metaDataSerializeOptions);

                    _metaDatas.Add(metaData.Id, metaData);
                }
                else
                {
                    var metaData = new MetaData(name, assetPath);

                    _metaDatas.Add(metaData.Id, metaData);

                    SaveMetaData(metaPath, metaData);
                }
            }
        }

        public MetaData GetMetaData(Guid id)
        {
            return _metaDatas.TryGetValue(id, out var metaData) ? metaData : throw new KeyNotFoundException($"MetaData with id {id} not found.");
        }
    }
}

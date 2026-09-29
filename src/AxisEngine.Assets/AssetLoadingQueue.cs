using AxisEngine.Core.Assets;
using AxisEngine.Core.Assets.Abstractions;

namespace AxisEngine.Assets
{
    public class AssetLoadingQueue : IAssetLoadingQueue
    {
        private readonly Queue<(Type, MetaData)> _loadingQueue;
        private readonly Dictionary<Type, IAssetImporter> _assetImporters;
        private readonly IAssetManager _assetManager;

        private int _countLoadingTheFrame = 0;

        public const int MaxLoadingTheFrame = 4;

        public AssetLoadingQueue(IAssetManager assetManager)
        {
            _assetManager = assetManager;

            _loadingQueue = new Queue<(Type, MetaData)>();
            _assetImporters = new Dictionary<Type, IAssetImporter>();
        }

        private async Task<IAsset> LoadAsset(Type type, MetaData metaData)
        {
            var assetImporter = GetAssetImporter(type);

            return await Task.Run(async () =>
                await assetImporter.Import(metaData));
        }

        public void AddToQueue(Type type, MetaData metaData)
        {
            _loadingQueue.Enqueue((type, metaData));
        }

        public void LoadAll()
        {
            _countLoadingTheFrame = 0;

            try
            {
                while (_loadingQueue.Count > 0 && _countLoadingTheFrame <= MaxLoadingTheFrame)
                {
                    (Type, MetaData) data = _loadingQueue.Dequeue();

                    var asset = LoadAsset(data.Item1, data.Item2).Result;

                    _assetManager.RegisterAsset(data.Item1, asset);

                    _countLoadingTheFrame++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }

        public void RegisterAssetImporter(IAssetImporter assetImporter)
        {
            _assetImporters[assetImporter.SupportedAsset] = assetImporter;
        }

        public IAssetImporter GetAssetImporter(Type type)
        {
            return _assetImporters.TryGetValue(type, out var assetImporter) ? assetImporter : throw new KeyNotFoundException($"AssetImporter with supported type {type} not found.");
        }
    }
}
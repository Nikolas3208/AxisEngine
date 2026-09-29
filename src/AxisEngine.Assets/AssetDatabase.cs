using AxisEngine.Core.Assets.Abstractions;

namespace AxisEngine.Assets
{
    public class AssetDatabase<T> : IAssetDatabase<T> where T : struct, IAsset
    {
        private readonly Dictionary<Guid, T> _assets;

        public AssetDatabase()
        {
            _assets = new Dictionary<Guid, T>();
        }

        public void AddAsset(IAsset asset)
        {
            if (_assets.ContainsKey(asset.Id))
                throw new KeyNotFoundException($"Asset with id {asset.Id} all ready exist.");

            _assets.Add(asset.Id, (T)asset);
        }

        public void AddAsset(T asset)
        {
            if (_assets.ContainsKey(asset.Id))
                throw new KeyNotFoundException($"Asset with id {asset.Id} all ready exist.");

            _assets.Add(asset.Id, asset);
        }

        public T GetAsset(Guid id)
        {
            return _assets.TryGetValue(id, out var asset) ? asset : throw new KeyNotFoundException($"Asset with id {asset.Id} not found.");
        }

        public bool HasAsset(Guid id)
        {
            return _assets.ContainsKey(id);
        }

        public void Dispose()
        {
            _assets.Clear();
        }
    }
}

namespace AxisEngine.Core.Assets.Abstractions
{
    public interface IAssetManager
    {
        void SetLoadingQueue(IAssetLoadingQueue assetLoadingQueue);

        (AssetStatus, T?) GetAsset<T>(Guid id) where T : struct, IAsset;

        AssetStatus GetAssetStatus(Guid id);

        void RegisterAsset(Type type, IAsset asset);

        bool HasAsset(Guid id);
        bool HasAsset<T>() where T : struct, IAsset;
        bool HasAsset<T>(Guid id) where T : struct, IAsset;

        public void LoadAllMetaData();

        public MetaData GetMetaData(Guid id);
    }
}

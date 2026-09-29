namespace AxisEngine.Core.Assets.Abstractions
{
    public interface IAssetLoadingQueue
    {
        void AddToQueue(Type type, MetaData metaData);

        void RegisterAssetImporter(IAssetImporter assetImporter);

        IAssetImporter GetAssetImporter(Type type);

        void LoadAll();
    }
}

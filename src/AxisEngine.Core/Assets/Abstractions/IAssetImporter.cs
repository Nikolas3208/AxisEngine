namespace AxisEngine.Core.Assets.Abstractions
{
    public interface IAssetImporter
    {
        Type SupportedAsset { get; }

        Task<IAsset> Import(MetaData metaData);
    }

    public interface IAssetImporter<T> : IAssetImporter where T : struct, IAsset
    {
        new Task<T> Import(MetaData metaData);
    }
}

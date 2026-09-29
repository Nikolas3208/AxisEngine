namespace AxisEngine.Core.Assets.Abstractions
{
    public interface IAsset : IDisposable
    {
        Guid Id { get; }
        string Name { get; }
        string FilePath { get; }

        IAssetData Data { get; }
    }
}

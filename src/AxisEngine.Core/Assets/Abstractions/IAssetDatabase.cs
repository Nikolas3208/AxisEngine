namespace AxisEngine.Core.Assets.Abstractions
{
    public interface IAssetDatabase : IDisposable
    {
        bool HasAsset(Guid id);

        void AddAsset(IAsset asset);
    }

    public interface IAssetDatabase<T> : IAssetDatabase where T : struct, IAsset 
    {
        void AddAsset(T asset);

        T GetAsset(Guid id);
    }
}

using AxisEngine.Core.Assets.Abstractions;

namespace AxisEngine.Core.Assets
{
    public struct MetaData : IDisposable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }

        public IAssetData AssetData { get; set; }

        public MetaData()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
            AssetData = default(NoneAssetData);
        }

        public MetaData(string name, string filePath)
        {
            Id = Guid.NewGuid();
            Name = name;
            FilePath = filePath;
            AssetData = default(NoneAssetData);
        }

        public MetaData(Guid id, string name, string filePath)
        {
            Id = id;
            Name = name;
            FilePath = filePath;
            AssetData = default(NoneAssetData);
        }

        public MetaData(Guid id, string name, string filePath, IAssetData data)
        {
            Id = id;
            Name = name;
            FilePath = filePath;
            AssetData = data;
        }

        public void Dispose()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
            AssetData = default(NoneAssetData);
        }
    }
}

using AxisEngine.Core.Assets.Abstractions;

namespace AxisEngine.Core.Graphics.Assets
{
    public struct Texture2DAsset : IAsset
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string FilePath { get; private set; }

        public Texture2DAssetData TextureData { get; private set; }

        public IAssetData Data => TextureData;

        public Texture2DAsset()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
        }

        public Texture2DAsset(string name, string filePath, Texture2DAssetData data)
        {
            Id = Guid.NewGuid();
            Name = name;
            FilePath = filePath;
            TextureData = data;
        }

        public Texture2DAsset(Guid id, string name, string filePath, Texture2DAssetData data)
        {
            Id = id;
            Name = name;
            FilePath = filePath;
            TextureData = data;
        }

        public void Dispose()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
            TextureData = default;
        }
    }
}

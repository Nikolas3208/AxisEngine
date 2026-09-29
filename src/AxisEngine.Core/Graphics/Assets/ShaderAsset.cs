using AxisEngine.Core.Assets.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AxisEngine.Core.Graphics.Assets
{
    public struct ShaderAsset : IAsset
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string FilePath { get; private set; }

        public ShaderAssetData ShaderData { get; private set; }

        public IAssetData Data => ShaderData;

        public ShaderAsset()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
            ShaderData = default;
        }

        public ShaderAsset(string name, string filePath, ShaderAssetData data)
        {
            Id = Guid.NewGuid();
            Name = name;
            FilePath = filePath;
            ShaderData = data;
        }

        public ShaderAsset(Guid id, string name, string filePath, ShaderAssetData data)
        {
            Id = id;
            Name = name;
            FilePath = filePath;
            ShaderData = data;
        }

        public void Dispose()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            FilePath = string.Empty;
            ShaderData = default;
        }
    }
}

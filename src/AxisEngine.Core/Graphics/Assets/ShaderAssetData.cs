using AxisEngine.Core.Assets.Abstractions;
using System.Text.Json.Serialization;

namespace AxisEngine.Core.Graphics.Assets
{
    public struct ShaderAssetData : IAssetData
    {
        [JsonIgnore]
        public string VertSource { get; private set; }

        [JsonIgnore]
        public string FragSource { get; private set; }

        public ShaderAssetData()
        {
            VertSource = string.Empty;
            FragSource = string.Empty;
        }

        public ShaderAssetData(string vertSource, string fragSource)
        {
            VertSource = vertSource;
            FragSource = fragSource;
        }
    }
}

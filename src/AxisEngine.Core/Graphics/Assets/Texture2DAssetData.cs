using AxisEngine.Core.Assets.Abstractions;
using System.Text.Json.Serialization;

namespace AxisEngine.Core.Graphics.Assets
{
    public struct Texture2DAssetData : IAssetData
    {
        [JsonIgnore]
        public byte[] Data { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public bool Repeat { get; set; }
        public bool Smooth { get; set; }

        public Texture2DAssetData()
        {
            Data = Array.Empty<byte>();
        }

        public Texture2DAssetData(byte[] data, int width, int height, bool repeat, bool smooth)
        {
            Data = data;
            Width = width;
            Height = height;
            Repeat = repeat;
            Smooth = smooth;
        }
    }
}

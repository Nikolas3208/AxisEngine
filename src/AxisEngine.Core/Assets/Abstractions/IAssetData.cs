using AxisEngine.Core.Graphics.Assets;
using System.Text.Json.Serialization;

namespace AxisEngine.Core.Assets.Abstractions
{
    [JsonDerivedType(typeof(NoneAssetData), typeDiscriminator: "noneData")]
    [JsonDerivedType(typeof(Texture2DAssetData), typeDiscriminator: "texture2D")]
    [JsonDerivedType(typeof(ShaderAssetData), typeDiscriminator: "shader")]
    public interface IAssetData
    {

    }
}

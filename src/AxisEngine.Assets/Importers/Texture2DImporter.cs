using AxisEngine.Core.Assets;
using AxisEngine.Core.Assets.Abstractions;
using AxisEngine.Core.Graphics.Assets;
using StbImageSharp;

namespace AxisEngine.Assets.Importers
{
    public class Texture2DImporter : IAssetImporter
    {
        public Type SupportedAsset => typeof(Texture2DAsset);

        public async Task<IAsset> Import(MetaData metaData)
        {
            if (!File.Exists(metaData.FilePath))
                throw new FileNotFoundException($"Texture from path {metaData.FilePath} not found.");

            Texture2DAssetData assetData = default;

            using (var stream = File.OpenRead(metaData.FilePath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                if(metaData.AssetData is Texture2DAssetData data)
                {
                    assetData = new Texture2DAssetData(image.Data, image.Width, image.Height, data.Repeat, data.Smooth);

                    return new Texture2DAsset(metaData.Id, metaData.Name, metaData.FilePath, assetData);
                }

                assetData = new Texture2DAssetData(image.Data, image.Width, image.Height, true, false);

                return new Texture2DAsset(metaData.Id, metaData.Name, metaData.FilePath, assetData);
            }
        }
    }
}

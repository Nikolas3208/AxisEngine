using AxisEngine.Core.Assets;
using AxisEngine.Core.Assets.Abstractions;
using AxisEngine.Core.Graphics.Assets;
using System.Text;

namespace AxisEngine.Assets.Importers
{
    public class ShaderImporter : IAssetImporter
    {
        public Type SupportedAsset => typeof(ShaderAsset);

        public async Task<IAsset> Import(MetaData metaData)
        {
            if (!File.Exists(metaData.FilePath))
                throw new FileNotFoundException($"Shader from path {metaData.FilePath} not found.");

            var data = await ParseShaderFromFile(metaData.FilePath);

            return new ShaderAsset(metaData.Id, metaData.Name, metaData.FilePath, data);
        }

        private async Task<ShaderAssetData> ParseShaderFromFile(string path)
        {
            string[] lines = await File.ReadAllLinesAsync(path);

            StringBuilder vertex = new StringBuilder();
            StringBuilder fragment = new StringBuilder();

            StringBuilder current = null!;
            bool nextShader = false;

            foreach (string line in lines)
            {
                if (nextShader && string.IsNullOrEmpty(line))
                {
                    nextShader = false;
                    continue;
                }

                if (line.Contains("#shader vertex"))
                {
                    current = vertex;
                    nextShader = true;
                    continue;
                }
                if (line.Contains("#shader fragment"))
                {
                    current = fragment;
                    nextShader = true;
                    continue;
                }
                current?.AppendLine(line);
            }

            return new ShaderAssetData(vertex.ToString(), fragment.ToString());
        }
    }
}

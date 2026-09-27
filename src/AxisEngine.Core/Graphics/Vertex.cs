using AxisEngine.Mathematics;

namespace AxisEngine.Core.Graphics
{
    public struct Vertex
    {
        public static int SizeInByte => sizeof(float) * 8;

        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCoord;

        public Vertex(Vector3 position)
        {
            Position = position;
        }

        public Vertex(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }

        public Vertex(Vector3 position, Vector2 texCoord)
        {
            Position = position;
            TexCoord = texCoord;
        }

        public Vertex(Vector3 position, Vector3 normal, Vector2 texCoord)
        {
            Position = position;
            Normal = normal;
            TexCoord = texCoord;
        }
    }
}

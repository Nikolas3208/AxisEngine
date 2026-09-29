using AxisEngine.Core.Graphics.Abstractions.Buffers;

namespace AxisEngine.Core.Graphics
{
    public struct VertexBufferLayout
    {
        public IVertexBuffer VertexBuffer { get; }

        public VertexBufferElement[] Elements;

        public VertexBufferLayout(IVertexBuffer vertexBuffer, params VertexBufferElement[] elements)
        {
            VertexBuffer = vertexBuffer;
            Elements = elements;
        }
    }
}

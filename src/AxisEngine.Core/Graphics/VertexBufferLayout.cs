namespace AxisEngine.Core.Graphics
{
    public struct VertexBufferLayout
    {
        public IVertexBuffer VertexBuffer { get; }

        public VertexBufferAttachment Attachment { get; }

        public VertexBufferLayout(IVertexBuffer vertexBuffer, VertexBufferAttachment attachment)
        {
            VertexBuffer = vertexBuffer;
            Attachment = attachment;
        }
    }
}

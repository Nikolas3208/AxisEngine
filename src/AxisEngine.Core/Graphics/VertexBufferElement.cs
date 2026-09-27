namespace AxisEngine.Core.Graphics
{
    public struct VertexBufferElement
    {
        public int Index { get; }
        public int Size { get; }
        public int Stride { get; }
        public int Offset { get; }

        public VertexBufferElement(int index, int size, int stride ,int offset)
        {
            Index = index;
            Size = size;
            Stride = stride;
            Offset = offset;
        }
    }
}

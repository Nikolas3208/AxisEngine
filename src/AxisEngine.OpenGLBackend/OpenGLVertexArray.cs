using AxisEngine.Core.Graphics;
using AxisEngine.Core.Graphics.Abstractions.Buffers;
using OpenTK.Graphics.OpenGL4;

namespace AxisEngine.OpenGLBackend
{
    public class OpenGLVertexArray : IBuffer
    {
        private IIndexBuffer? _indexBuffer;
        private List<VertexBufferLayout> _vertexBufferLayouts;

        public int Handle { get; }

        public int Count { get; private set; }

        public OpenGLVertexArray()
        {
            _vertexBufferLayouts = new List<VertexBufferLayout>();

            Handle = GL.GenVertexArray();
        }

        public void SetIndexBuffer(IIndexBuffer indexBuffer)
        {
            _indexBuffer = indexBuffer;
        }

        public void AddVertexBufferLayout(VertexBufferLayout bufferLayout)
        {
            _vertexBufferLayouts.Add(bufferLayout);

            GL.BindVertexArray(Handle);
            bufferLayout.VertexBuffer.Bind();
            _indexBuffer?.Bind();

            foreach(var elements in bufferLayout.Elements)
            {
                GL.EnableVertexAttribArray(elements.Index);
                GL.VertexAttribPointer(elements.Index, elements.Size, VertexAttribPointerType.Float, false, elements.Stride, elements.Offset);
            }

            GL.BindVertexArray(0);

            Count += bufferLayout.VertexBuffer.Count;
        }

        public void Bind()
        {
            GL.BindVertexArray(Handle);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            if(Handle != 0)
            {
                GL.BindVertexArray(0);
                GL.DeleteVertexArray(Handle);
            }
        }
    }
}

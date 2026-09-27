using AxisEngine.Core.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace AxisEngine.OpenGLBackend
{
    public class OpenGLVertexBuffer : IVertexBuffer
    {
        public int Handle { get; }

        public int Count { get; }

        public OpenGLVertexBuffer(Vertex[] vertices)
        {
            Handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertex.SizeInByte * vertices.Length, vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            Count = vertices.Length;
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }


        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Dispose()
        {
            if(Handle != 0)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                GL.DeleteBuffer(Handle);
            }
        }
    }
}

using AxisEngine.Core.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace AxisEngine.OpenGLBackend
{
    internal class OpenGLIndexBuffer : IIndexBuffer
    {
        public int Handle { get; }

        public int Count { get; }

        public OpenGLIndexBuffer(uint[] indices)
        {
            Handle = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(uint) * indices.Length, indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        }


        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Dispose()
        {
            if(Handle != 0)
            {
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
                GL.DeleteBuffer(Handle);
            }
        }
    }
}

namespace AxisEngine.Core.Graphics.Abstractions.Buffers
{
    public interface IBuffer : IDisposable
    {
        int Handle { get; }

        void Bind();
        void Unbind();
    }
}

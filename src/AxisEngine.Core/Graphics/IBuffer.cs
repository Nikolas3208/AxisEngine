namespace AxisEngine.Core.Graphics
{
    public interface IBuffer : IDisposable
    {
        int Handle { get; }

        void Bind();
        void Unbind();
    }
}

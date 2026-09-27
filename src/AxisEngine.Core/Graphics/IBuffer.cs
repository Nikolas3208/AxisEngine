namespace AxisEngine.Core.Graphics
{
    public interface IBuffer : IDisposable
    {
        uint Handle { get; }

        void Bind();
        void Unbind();
    }
}

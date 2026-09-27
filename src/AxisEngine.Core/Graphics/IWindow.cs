using AxisEngine.Mathematics;

namespace AxisEngine.Core.Graphics
{
    public interface IWindow : IDisposable
    {
        event Action OnLoad;
        event Action OnUpdate;
        event Action OnRender;
        event Action<EventArgsResize> OnResize;
        event Action OnClose;

        void Run();

        void ClearBuffers();
        void ClearColor(Color3 color);
        void ClearColor(Color4 color);

        void SwapBuffers();
    }
}

using AxisEngine.Core.Graphics;
using AxisEngine.Core.Graphics.Abstractions;
using AxisEngine.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;

namespace AxisEngine.OpenGLBackend
{
    public class OpenGLWindow : IWindow
    {
        private readonly GameWindow _window;

        public event Action? OnLoad;
        public event Action? OnUpdate;
        public event Action? OnRender;
        public event Action<EventArgsResize>? OnResize;
        public event Action? OnClose;

        public OpenGLWindow(GraphicsContext context)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Title = context.Title,
                ClientSize = new OpenTK.Mathematics.Vector2i(context.Width, context.Height)
            };

            _window = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);

            _window.Load += () => { OnLoad?.Invoke(); };
            _window.UpdateFrame += (_) => { OnUpdate?.Invoke(); };
            _window.RenderFrame += (_) => { OnRender?.Invoke(); };
            _window.Resize += (e) => { OnResize?.Invoke(new EventArgsResize(new Vector2i(e.Width, e.Height))); };
            _window.Closing += (_) => { OnClose?.Invoke(); };

        }

        public void ClearBuffers(Core.Graphics.ClearBufferMask mask)
        {
            GL.Clear((OpenTK.Graphics.OpenGL4.ClearBufferMask)mask);
        }

        public void ClearColor(Color3 color)
        {
            GL.ClearColor(color.R, color.G, color.B, 1f);
        }

        public void ClearColor(Color4 color)
        {
            GL.ClearColor(color.R, color.G, color.B, color.A);
        }

        public void Run()
        {
            _window.Run();
        }

        public void SwapBuffers()
        {
            _window.SwapBuffers();
        }

        public void Dispose()
        {
            _window.Dispose();
        }
    }
}

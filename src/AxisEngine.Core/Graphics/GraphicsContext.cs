namespace AxisEngine.Core.Graphics
{
    public struct GraphicsContext
    {
        public API Api { get; }

        public string Title { get; }

        public int Width { get; }
        public int Height { get; }

        public GraphicsContext()
        {
            Api = API.OpenGL;

            Title = "AxisEngine";

            Width = 800;
            Height = 600;
        }

        public GraphicsContext(API api, string title, int width, int height)
        {
            Api = api;

            Title = title;

            Width = width;
            Height = height;
        }
    }
}

using AxisEngine.Assets;
using AxisEngine.Assets.Importers;
using AxisEngine.Core.Assets;
using AxisEngine.Core.Assets.Abstractions;
using AxisEngine.Core.Graphics;
using AxisEngine.Core.Graphics.Abstractions;
using AxisEngine.Core.Graphics.Abstractions.Resources;
using AxisEngine.Core.Graphics.Assets;
using AxisEngine.Mathematics;
using AxisEngine.OpenGLBackend;
using OpenTK.Graphics.OpenGL4;

using ClearBufferMask = AxisEngine.Core.Graphics.ClearBufferMask;

namespace SundBox
{

    public class Program
    {
        private static IWindow _window;

        private static IShader _shader;
        private static OpenGLVertexArray _vertexArray;


        private static IAssetManager _assetManager;
        private static IAssetLoadingQueue _assetLoadingQueue;


        private static Vertex[] _vertices =
        {
            new Vertex(new Vector3(0.0f, 0.5f, 0.0f)),
            new Vertex(new Vector3(-0.5f, 0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, 0.0f, 0.0f))
        };

        public static void Main()
        {
            _window = new OpenGLWindow(new GraphicsContext());

            _window.OnLoad += Window_OnLoad;
            _window.OnUpdate += Window_OnUpdate;
            _window.OnRender += Window_OnRender;
            _window.OnClose += Window_OnClose;

            _window.Run();
        }

        private static void Window_OnLoad()
        {
            GL.Enable(EnableCap.DepthTest);

            _assetManager = new AssetManager("Assets");
            _assetLoadingQueue = new AssetLoadingQueue(_assetManager);
            _assetLoadingQueue.RegisterAssetImporter(new ShaderImporter());
            _assetLoadingQueue.RegisterAssetImporter(new Texture2DImporter());

            _assetManager.SetLoadingQueue(_assetLoadingQueue);

            _assetManager.LoadAllMetaData();
        }

        private static void Window_OnUpdate()
        {
            var shader = _assetManager.GetAsset<ShaderAsset>(new Guid("f78931d3-98e1-4cc9-9a9f-8c1a51b1c8ed")); 
            var texture = _assetManager.GetAsset<Texture2DAsset>(new Guid("79e2bb12-3d61-40d5-85a3-6d6c668c3b7d"));

            _assetLoadingQueue.LoadAll();
        }

        private static void Window_OnRender()
        {
            _window.ClearBuffers(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _window.ClearColor(Color4.Black);

            _window.SwapBuffers();
        }

        private static void Window_OnClose()
        {
            _vertexArray?.Dispose();
            _shader?.Dispose();
        }
    }
}


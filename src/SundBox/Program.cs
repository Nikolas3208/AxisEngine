using AxisEngine.Core.Graphics;
using AxisEngine.Mathematics;
using AxisEngine.OpenGLBackend;
using OpenTK.Graphics.OpenGL4;

using ClearBufferMask = AxisEngine.Core.Graphics.ClearBufferMask;

namespace SundBox
{

    public class Program
    {
        private static IWindow _window;

        private static OpenGLShader _shader;
        private static OpenGLVertexArray _vertexArray;


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

            int handleShader = 0;

            var shaderSource = File.ReadAllText("Assets\\Shaders\\shader.vert");

            var vertexShader = GL.CreateShader(ShaderType.VertexShader);

            GL.ShaderSource(vertexShader, shaderSource);

            CompileShader(vertexShader);

            shaderSource = File.ReadAllText("Assets\\Shaders\\shader.frag");
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderSource);
            CompileShader(fragmentShader);

            handleShader = GL.CreateProgram();

            GL.AttachShader(handleShader, vertexShader);
            GL.AttachShader(handleShader, fragmentShader);

            LinkProgram(handleShader);

            GL.DetachShader(handleShader, vertexShader);
            GL.DetachShader(handleShader, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

            _shader = new OpenGLShader(handleShader);

            _vertexArray = new OpenGLVertexArray();

            _vertexArray.AddVertexBufferLayout(new VertexBufferLayout(new OpenGLVertexBuffer(_vertices), new VertexBufferElement(0, 3, Vertex.SizeInByte, 0)));
            
            _shader.Use();
        }

        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }
        }

        private static void LinkProgram(int program)
        {
            GL.LinkProgram(program);

            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                throw new Exception($"Error occurred whilst linking Program({program})");
            }
        }

        private static void Window_OnUpdate()
        {
            
        }

        private static void Window_OnRender()
        {
            _window.ClearBuffers(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _window.ClearColor(Color4.Black);

            _shader.Use();

            _vertexArray.Bind();
            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertexArray.Count);

            _window.SwapBuffers();
        }

        private static void Window_OnClose()
        {
            _vertexArray.Dispose();
            _shader.Dispose();
        }
    }
}


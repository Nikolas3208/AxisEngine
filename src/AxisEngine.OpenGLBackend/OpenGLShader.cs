using AxisEngine.Core.Graphics;
using AxisEngine.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace AxisEngine.OpenGLBackend
{
    public class OpenGLShader : IShader
    {
        private readonly Dictionary<string, int> _uniformLocations;

        public int Handle { get; }

        public OpenGLShader(int handle)
        {
            Handle = handle;

            _uniformLocations = GetUniformLocations();
        }

        private Dictionary<string, int> GetUniformLocations()
        {
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            var uniformLocations = new Dictionary<string, int>();

            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(Handle, i, out _, out _);

                var location = GL.GetUniformLocation(Handle, key);

                uniformLocations.Add(key, location);
            }

            return uniformLocations;
        }

        public int GetUniformLocation(string name)
            => _uniformLocations.TryGetValue(name, out int location) ? location : -1;

        public bool HasUniform(string name)
            => _uniformLocations.ContainsKey(name);

        public bool TryGetUniform(string name, out int location)
            => _uniformLocations.TryGetValue(name, out location);

        public void SetBool(string name, bool value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform1(location, value ? 1 : 0);
        }


        public void SetInt(string name, int value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform1(location, value);
        }

        public void SetFloat(string name, float value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform1(location, value);
        }

        public void SetVector2(string name, Vector2 value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform2(location, value.X, value.Y);
        }

        public void SetVector3(string name, Vector3 value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform3(location, value.X, value.Y, value.Z);
        }

        public void SetVector4(string name, Vector4 value)
        {
            if (TryGetUniform(name, out int location))
                GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Dispose()
        {
            if(Handle != 0)
            {
                GL.UseProgram(0);
                GL.DeleteProgram(Handle);
            }
        }
    }
}

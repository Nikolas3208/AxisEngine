using AxisEngine.Mathematics;

namespace AxisEngine.Core.Graphics
{
    public interface IShader : IDisposable
    {
        int Handle { get; }

        bool HasUniform(string name);
        int GetUniformLocation(string name);

        bool TryGetUniform(string name, out int location);

        void SetBool(string name, bool value);
        void SetInt(string name, int value);
        void SetFloat(string name, float value);
        void SetVector2(string name, Vector2 value);
        void SetVector3(string name, Vector3 value);
        void SetVector4(string name, Vector4 value);

        void Use();
    }
}

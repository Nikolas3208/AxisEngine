namespace AxisEngine.Mathematics
{
    public struct Vector4
    {
        public static Vector4 Zero => new Vector4(0, 0, 0, 0);
        public static Vector4 One => new Vector4(1, 1, 1, 1);

        public static Vector4 UnitX => new Vector4(1, 0, 0, 0);
        public static Vector4 UnitY => new Vector4(0, 1, 0, 0);
        public static Vector4 UnitZ => new Vector4(0, 0, 1, 0);
        public static Vector4 UnitW => new Vector4(0, 0, 0, 1);

        public static int SizeInByte => sizeof(float) * 4;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        public Vector4(Vector4 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
            W = vector.W;
        }

        public Vector4(Vector3 vector, float w = 0)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
            W = w;
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector4 operator -(Vector4 vector)
            => new Vector4(-vector.X, -vector.Y, -vector.Z, -vector.W);

        public static Vector4 operator +(Vector4 left, Vector4 right)
            => new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        public static Vector4 operator -(Vector4 left, Vector4 right)
            => new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        public static Vector4 operator *(Vector4 vector, float scalar)
            => new Vector4(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);

        public static Vector4 operator /(Vector4 vector, float scalar)
            => new Vector4(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);
    }
}

namespace AxisEngine.Mathematics
{
    public struct Vector3
    {
        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);

        public static Vector3 UnitX => new Vector3(1, 0, 0);
        public static Vector3 UnitY => new Vector3(0, 1, 0);
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        public static int SizeInByte => sizeof(float) * 3;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Vector3(Vector2 vector, float z = 0)
        {
            X = vector.X;
            Y = vector.Y;
            Z = z;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator -(Vector3 vector)
            => new Vector3(-vector.X, -vector.Y, -vector.Z);

        public static Vector3 operator +(Vector3 left, Vector3 right)
            => new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static Vector3 operator -(Vector3 left, Vector3 right)
            => new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static Vector3 operator *(Vector3 vector, float scalar)
            => new Vector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        public static Vector3 operator /(Vector3 vector, float scalar)
            => new Vector3(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
    }
}
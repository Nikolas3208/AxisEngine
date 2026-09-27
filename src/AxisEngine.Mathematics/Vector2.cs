namespace AxisEngine.Mathematics
{
    public struct Vector2
    {
        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);

        public static Vector2 UnitX => new Vector2(1, 0);
        public static Vector2 UnitY => new Vector2(0, 1);

        public static int SizeInByte => sizeof(float) * 2;

        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator -(Vector2 vector)
            => new Vector2(-vector.X, -vector.Y);

        public static Vector2 operator +(Vector2 left, Vector2 right)
            => new Vector2(left.X + right.X, left.Y + right.Y);

        public static Vector2 operator -(Vector2 left, Vector2 right)
            => new Vector2(left.X - right.X, left.Y - left.Y);

        public static Vector2 operator *(Vector2 vector, float scalar)
            => new Vector2(vector.X * scalar, vector.Y * scalar);

        public static Vector2 operator /(Vector2 vector, float scalar)
            => new Vector2(vector.X / scalar, vector.Y / scalar);
    }
}

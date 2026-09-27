namespace AxisEngine.Mathematics
{
    public struct Vector2i
    {
        public static Vector2i Zero => new Vector2i(0, 0);
        public static Vector2i One => new Vector2i(1, 1);

        public static Vector2i UnitX => new Vector2i(1, 0);
        public static Vector2i UnitY => new Vector2i(0, 1);

        public static int SizeInByte => sizeof(int) * 2;

        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i(int value)
        {
            X = value;
            Y = value;
        }

        public Vector2i(Vector2i vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2i operator -(Vector2i vector)
            => new Vector2i(-vector.X, -vector.Y);

        public static Vector2i operator +(Vector2i left, Vector2i right)
            => new Vector2i(left.X + right.X, left.Y + right.Y);

        public static Vector2i operator -(Vector2i left, Vector2i right)
            => new Vector2i(left.X - right.X, left.Y - right.Y);

        public static Vector2i operator *(Vector2i vector, int scalar)
            => new Vector2i(vector.X * scalar, vector.Y * scalar);

        public static Vector2i operator /(Vector2i vector, int scalar)
            => new Vector2i(vector.X / scalar, vector.Y / scalar);
    }
}

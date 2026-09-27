namespace AxisEngine.Mathematics
{
    public struct Color4
    {
        public static Color4 Black => new Color4(0, 0, 0, 1);
        public static Color4 White => new Color4(1, 1, 1, 1);

        public static Color4 Red => new Color4(1, 0, 0, 1);
        public static Color4 Grean => new Color4(0, 1, 0, 1);
        public static Color4 Blue => new Color4(0, 0, 1, 1);

        public static int SizeInByte => sizeof(float) * 4;

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public Color4(Color4 color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public Color4(Color3 color, float a = 1)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = a;
        }

        public Color4(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}

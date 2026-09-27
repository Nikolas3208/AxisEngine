namespace AxisEngine.Mathematics
{
    public struct Color3
    {
        public static Color3 Black => new Color3(0, 0, 0);
        public static Color3 White => new Color3(1, 1, 1);

        public static Color3 Red => new Color3(1, 0, 0);
        public static Color3 Grean => new Color3(0, 1, 0);
        public static Color3 Blue => new Color3(0, 0, 1);


        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public Color3(Color3 color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public Color3(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}

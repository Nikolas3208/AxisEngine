using AxisEngine.Mathematics;

namespace AxisEngine.Core.Graphics
{
    public class EventArgsResize
    {
        public Vector2i Size;

        public EventArgsResize(Vector2i size)
        {
            Size = size;
        }
    }
}

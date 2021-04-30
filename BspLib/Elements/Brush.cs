using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Brush
    {
        public int FirstBrushside;
        public int NumberBrushsides;
        public int TextureIndex;
    }
}

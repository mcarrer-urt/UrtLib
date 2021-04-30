using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BrushSide
    {
        public int PlaneIndex;
        public int TextureIndex;
    }
}

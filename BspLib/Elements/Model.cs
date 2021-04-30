using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Model
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Mins;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Maxs;
        public int FirstFace;
        public int NumberFaces;
        public int FirstBrush;
        public int NumberBrushes;
    }
}

using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Leaf
    {
        public int VisdataClusterIndex;
        public int AreaportalArea;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Mins;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Maxs;
        public int FirstLeafFace;
        public int NumberLeafFaces;
        public int FirstLeafBrush;
        public int NumberLeafBrushes;
    }
}

using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public int PlaneIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] ChildrenIndices;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Mins;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Maxs;
    }
}

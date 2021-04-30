using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Plane
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Normal;
        public float Distance;
    }
}

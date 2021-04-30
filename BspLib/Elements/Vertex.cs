using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Position;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * 2)]
        public float[,] TextureCoordinates;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Normal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Color;
    }
}

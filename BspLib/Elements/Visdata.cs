using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Visdata
    {
        public int NumberVectors;
        public int VectorSize;
        public byte[] Vectors;
    }
}

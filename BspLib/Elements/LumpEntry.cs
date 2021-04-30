using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LumpEntry
    {
        public int Offset;
        public int Length;
    }
}

using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Header
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] Magic;
        public int Version;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public LumpEntry[] Entries;
    }
}

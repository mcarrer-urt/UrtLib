using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LightMap
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128 * 128 * 2)]
        public byte[, ,] Data;
    }
}

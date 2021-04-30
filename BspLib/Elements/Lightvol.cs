using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LightVol
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] AmbientColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] DirectionalColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Direction;
    }
}

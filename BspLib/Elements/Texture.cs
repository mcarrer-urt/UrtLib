using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Texture
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Name;
        public int SurfaceFlags;
        public int ContentsFlags;
    }
}

using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Entity
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;
    }
}

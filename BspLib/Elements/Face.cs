using System.Runtime.InteropServices;

namespace BspLib.Elements
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Face
    {
        public int TextureIndex;
        public int EffectIndex;
        public int Type;
        public int FirstVertex;
        public int NumberVertexes;
        public int FirstMeshvert;
        public int NumberMeshverts;
        public int LightmapIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] LightmapStart;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] LightmapSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] LightmapOrigin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * 3)]
        public float[,] LightmapVectors;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] SurfaceNormal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] Size;
    }
}

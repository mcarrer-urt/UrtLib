using BspLib.Elements;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BspLib
{
    public static class BspReader
    {

        public static Bsp Read(string filepath)
        {
            byte[] dataBuffer = File.ReadAllBytes(filepath);
            GCHandle hDataBuffer = GCHandle.Alloc(dataBuffer, GCHandleType.Pinned);
            IntPtr ptr = hDataBuffer.AddrOfPinnedObject();

            Bsp bsp = new Bsp
            {
                Header = Marshal.PtrToStructure<Header>(ptr)
            };

            bsp.Entity = ReadEntityLump(ptr, bsp.Header.Entries[0]);
            bsp.Textures = ReadBasicLump<Texture>(ptr, bsp.Header.Entries[1]);
            bsp.Planes = ReadBasicLump<Plane>(ptr, bsp.Header.Entries[2]);
            bsp.Nodes = ReadBasicLump<Node>(ptr, bsp.Header.Entries[3]);
            bsp.Leafs = ReadBasicLump<Leaf>(ptr, bsp.Header.Entries[4]);
            bsp.LeafFaces = ReadBasicLump<LeafFace>(ptr, bsp.Header.Entries[5]);
            bsp.LeafBrushs = ReadBasicLump<LeafBrush>(ptr, bsp.Header.Entries[6]);
            bsp.Models = ReadBasicLump<Model>(ptr, bsp.Header.Entries[7]);
            bsp.Brushs = ReadBasicLump<Brush>(ptr, bsp.Header.Entries[8]);
            bsp.BrushSides = ReadBasicLump<BrushSide>(ptr, bsp.Header.Entries[9]);
            bsp.Vertices = ReadBasicLump<Vertex>(ptr, bsp.Header.Entries[10]);
            bsp.MeshVerts = ReadBasicLump<MeshVert>(ptr, bsp.Header.Entries[11]);
            bsp.Effects = ReadBasicLump<Effect>(ptr, bsp.Header.Entries[12]);
            bsp.Faces = ReadBasicLump<Face>(ptr, bsp.Header.Entries[13]);
            bsp.LightMaps = ReadBasicLump<LightMap>(ptr, bsp.Header.Entries[14]);
            bsp.LightVols = ReadBasicLump<LightVol>(ptr, bsp.Header.Entries[15]);
            bsp.Visdata = ReadVisDataLump(ptr, bsp.Header.Entries[16]);

            return bsp;
        }

        private static T[] ReadBasicLump<T>(IntPtr ptr, LumpEntry def)
        {
            IntPtr lumpPtr = ptr + def.Offset;

            int elementSize = Marshal.SizeOf<T>();
            int elementCount = def.Length / elementSize;
            T[] lump = new T[elementCount];
            for (int i = 0; i < elementCount; i++)
                lump[i] = Marshal.PtrToStructure<T>(lumpPtr + i * elementSize);
            return lump;
        }

        private static Entity ReadEntityLump(IntPtr ptr, LumpEntry def)
        {
            IntPtr lumpPtr = ptr + def.Offset;
            return new Entity { Name = Marshal.PtrToStringAnsi(lumpPtr, def.Length) };
        }

        private static Visdata ReadVisDataLump(IntPtr ptr, LumpEntry def)
        {
            Visdata visData = new Visdata();

            if(def.Length > 0)
            {
                IntPtr lumpPtr = ptr + def.Offset;

                visData.NumberVectors = Marshal.ReadInt32(lumpPtr);
                visData.VectorSize = Marshal.ReadInt32(lumpPtr + sizeof(int));
                visData.Vectors = new byte[visData.NumberVectors * visData.VectorSize];

                Marshal.Copy(lumpPtr + 2 * sizeof(int), visData.Vectors, 0, visData.Vectors.Length);
            }

            return visData;
        }

    }
}

using BspLib.Elements;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BspLib
{
    public static class BspWriter
    {
        public static void Write(Bsp bsp, string location)
        {
            int headerFixedSize = 200;

            byte[][] lumpsBytes = new byte[][]
            {
                GetEntityLumpBytes(bsp.Entity),
                GetLumpBytes(bsp.Textures),
                GetLumpBytes(bsp.Planes),
                GetLumpBytes(bsp.Nodes),
                GetLumpBytes(bsp.Leafs),
                GetLumpBytes(bsp.LeafFaces),
                GetLumpBytes(bsp.LeafBrushs),
                GetLumpBytes(bsp.Models),
                GetLumpBytes(bsp.Brushs),
                GetLumpBytes(bsp.BrushSides),
                GetLumpBytes(bsp.Vertices),
                GetLumpBytes(bsp.MeshVerts),
                GetLumpBytes(bsp.Effects),
                GetLumpBytes(bsp.Faces),
                GetLumpBytes(bsp.LightMaps),
                GetLumpBytes(bsp.LightVols),
                GetVisdataBytes(bsp.Visdata)
            };

            int currentOffset = headerFixedSize;

            for (int i = 0; i < lumpsBytes.Length; i++)
            {
                bsp.Header.Entries[i] = new LumpEntry
                {
                    Length = lumpsBytes[i].Length,
                    Offset = currentOffset
                };
                currentOffset += lumpsBytes[i].Length;
            }

            byte[] bytesHeader = GetStructureBytes(bsp.Header, headerFixedSize);

            byte[] mergedLumpsBytes = Combine(lumpsBytes);

            byte[] finalBytes = Combine(bytesHeader, mergedLumpsBytes);

            File.WriteAllBytes(location, finalBytes);
        }

        public static byte[] GetStructureBytes(object obj, int fixedSize = 0)
        {
            int size = fixedSize > 0 ? fixedSize : Marshal.SizeOf(obj);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] ret = new byte[arrays.Sum(x => x.Length)];
            int offset = 0;
            foreach (byte[] data in arrays)
            {
                Buffer.BlockCopy(data, 0, ret, offset, data.Length);
                offset += data.Length;
            }
            return ret;
        }


        public static byte[] GetLumpBytes<T>(T[] arr)
        {
            return Combine(arr.Select(x => GetStructureBytes(x)).ToArray());
        }

        public static byte[] GetEntityLumpBytes(Entity entity)
        {
            return Encoding.ASCII.GetBytes(entity.Name);
        }

        private static byte[] GetVisdataBytes(Visdata visdata)
        {
            byte[] bytesNumVectors = BitConverter.GetBytes(visdata.NumberVectors);
            byte[] bytesVectorSize = BitConverter.GetBytes(visdata.VectorSize);
            return Combine(bytesNumVectors, bytesVectorSize, visdata.Vectors);
        }

    }
}

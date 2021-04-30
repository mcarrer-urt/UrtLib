using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapLib
{
    public static class MapWriter
    {
        public static void Write(Map map, string filepath)
        {
            File.WriteAllText(filepath, map.ToString(), Encoding.UTF8);
        }
    }
}

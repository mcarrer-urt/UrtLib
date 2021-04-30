using MapLib.Elements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MapLib
{
    public class Map
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public Map() { }

        public Map(string filepath)
        {
            Map map = MapReader.ReadFile(filepath);

            Entities = map.Entities;
        }

        public void Save(string filepath)
        {
            MapWriter.Write(this, filepath);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var entity in this.Entities)
                sb.AppendLine(entity.ToString());

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MapLib.Elements
{
    public class Entity
    {
        public List<EntityKey> Keys { get; set; } = new List<EntityKey>();
        public List<EntityElement> Elements { get; set; } = new List<EntityElement>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine(string.Join(Environment.NewLine, Keys));
            sb.AppendLine(string.Join(Environment.NewLine, Elements));
            sb.AppendLine("}");

            return sb.ToString() ;
        }
    }
}

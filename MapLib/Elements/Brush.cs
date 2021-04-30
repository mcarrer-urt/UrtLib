using System.Collections.Generic;
using System.Text;

namespace MapLib.Elements
{
    public class Brush: EntityElement
    {
        public List<Face> Faces { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("{");

            foreach (var face in this.Faces)
                sb.AppendLine(face.ToString());

            sb.AppendLine("}");


            return sb.ToString();
        }
    }
}

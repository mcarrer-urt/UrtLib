using System.Text;

namespace MapLib.Elements
{
    public class Patch: EntityElement
    {
        public string Texture { get; set; }
        public PatchVertex[,] Vertices { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine("patchDef2");
            sb.AppendLine("{");
            sb.AppendLine(string.IsNullOrEmpty(this.Texture) ? "NULL" : this.Texture);
            sb.AppendFormat("( {0} {1} 0 0 0 )", this.Vertices.GetLength(0), this.Vertices.GetLength(1));
            sb.AppendLine();
            sb.AppendLine("(");

            for (int i = 0; i < this.Vertices.GetLength(0); i++)
            {
                sb.Append("(");

                for (int j = 0; j < this.Vertices.GetLength(1); j++)
                    sb.AppendLine(this.Vertices[i, j].ToString());

                sb.AppendLine(")");
            }
            sb.AppendLine(")");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}

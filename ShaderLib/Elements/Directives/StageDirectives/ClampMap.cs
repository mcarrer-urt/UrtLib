namespace ShaderLib.Elements.Directives.StageDirectives
{
    public class ClampMap : StageDirective
    {
        public string TextureName { get; set; }

        public ClampMap(string textureName)
        {
            this.TextureName = textureName;
        }

        public override string ToString()
        {
            return "clampMap \"" + this.TextureName + '\"';
        }
    }
}

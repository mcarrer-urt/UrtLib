namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapNormalImage: Q3MapDirective
    {
        public string TextureName { get; set; }

        public Q3MapNormalImage(string textureName)
        {
            this.TextureName = textureName;
        }

        public override string ToString()
        {
            return "q3map_normalImage \"" + this.TextureName + '\"';
        }
    }
}

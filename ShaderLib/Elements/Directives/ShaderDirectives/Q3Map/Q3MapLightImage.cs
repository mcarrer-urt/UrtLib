namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightImage: Q3MapDirective
    {
        public string TextureName { get; set; }

        public Q3MapLightImage(string textureName)
        {
            this.TextureName = textureName;
        }
        public override string ToString()
        {
            return "q3map_lightImage \"" + this.TextureName + '\"';
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapSize : Q3MapDirective
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Q3MapLightmapSize(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return "q3map_lightmapSize " + this.Width + " " + this.Height;
        }
    }
}

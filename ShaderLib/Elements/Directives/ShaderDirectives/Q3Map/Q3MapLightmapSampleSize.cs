namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapSampleSize: Q3MapDirective
    {
        public int Value { get; set; }

        public Q3MapLightmapSampleSize(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_lightmapSampleSize " + this.Value;
        }
    }
}

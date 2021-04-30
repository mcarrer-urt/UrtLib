namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapBrightness: Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapLightmapBrightness(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_lightmapBrightness " + this.Value;
        }
    }
}

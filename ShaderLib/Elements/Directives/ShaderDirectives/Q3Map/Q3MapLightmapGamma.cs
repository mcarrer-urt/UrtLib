namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapGamma: Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapLightmapGamma(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_lightmapGamma " + this.Value;
        }
    }
}

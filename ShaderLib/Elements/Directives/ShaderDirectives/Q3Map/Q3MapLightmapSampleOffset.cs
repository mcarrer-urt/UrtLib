namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapSampleOffset: Q3MapDirective
    {
        public float Distance { get; set; }

        public Q3MapLightmapSampleOffset(float distance)
        {
            this.Distance = distance;
        }

        public override string ToString()
        {
            return "q3map_lightmapSampleOffset " + this.Distance;
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapFilterRadius : Q3MapDirective
    {
        public float Self { get; set; }
        public float Other { get; set; }

        public Q3MapLightmapFilterRadius(float self, float other)
        {
            this.Self = self;
            this.Other = other;
        }

        public override string ToString()
        {
            return "q3map_lightmapFilterRadius " + this.Self + " " + this.Other;
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapFur : Q3MapDirective
    {
        public float Layers { get; set; }
        public float Offset { get; set; }
        public float Fade { get; set; }

        public Q3MapFur(float layers, float offset, float fade)
        {
            this.Layers = layers;
            this.Offset = offset;
            this.Fade = fade;
        }

        public override string ToString()
        {
            return "q3map_fur " + this.Layers + " " + this.Offset + " " + this.Fade;
        }
    }
}

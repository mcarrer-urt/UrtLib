namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightRGB : Q3MapDirective
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapLightRGB(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return "q3map_lightRGB " + this.Red + " " + this.Green + " " + this.Blue;
        }
    }
}

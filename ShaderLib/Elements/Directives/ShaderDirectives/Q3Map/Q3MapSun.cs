namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapSun : Q3MapDirective
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Intensity { get; set; }
        public float Degrees { get; set; }
        public float Elevation { get; set; }

        public Q3MapSun(float red, float green, float blue, float intensity, float degrees, float elevation)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Intensity = intensity;
            this.Degrees = degrees;
            this.Elevation = elevation;
        }

        public override string ToString()
        {
            return "q3map_sun " + this.Red + " " + this.Green + " " + this.Blue + " " + this.Intensity + " " + this.Degrees + " " + this.Elevation;
        }
    }
}

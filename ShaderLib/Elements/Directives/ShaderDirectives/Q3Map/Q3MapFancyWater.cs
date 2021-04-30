namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapFancyWater: Q3MapDirective
    {
        public float Scale { get; set; }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapFancyWater(float scale, float red, float green, float blue)
        {
            this.Scale = scale;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
        public override string ToString()
        {
            return "q3map_fancyWater " + this.Scale + " " + this.Red + " " + this.Green + " " + this.Blue;
        }
    }
}

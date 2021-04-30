namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapCheapWater: Q3MapDirective
    {
        public float Scale { get; set; }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapCheapWater(float scale, float red, float green, float blue)
        {
            this.Scale = scale;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
        public override string ToString()
        {
            return "q3map_cheapWater " + this.Scale + " " + this.Red + " " + this.Green + " " + this.Blue;
        }
    }
}

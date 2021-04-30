namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapRGBGen : Q3MapDirective
    {

        public override string ToString()
        {
            return "q3map_RGBGen";
        }
    }

    public class Q3MapRGBGenConst : Q3MapRGBGen
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapRGBGenConst(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return base.ToString() + " const ( " + this.Red + " " + this.Green + " " + this.Blue + " )";
        }
    }
}

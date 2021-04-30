namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapColorGen : Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_colorGen";
        }
    }

    public class Q3MapColorGenConst : Q3MapColorGen
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapColorGenConst(float red, float green, float blue)
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

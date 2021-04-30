namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapColorMod: Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_colorMod";
        }
    }

    public class Q3MapColorModScale : Q3MapColorMod
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapColorModScale(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return base.ToString() + " scale ( " + this.Red + " " + this.Green + " " + this.Blue + " )"; ;
        }
    }

    public class Q3MapColorModSet : Q3MapColorMod
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapColorModSet(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return base.ToString() + " set ( " + this.Red + " " + this.Green + " " + this.Blue + ")"; ;
        }
    }

    public class Q3MapColorModVolume : Q3MapColorMod
    {

        public override string ToString()
        {
            return base.ToString() + " volume"; ;
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapRGBMod: Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_RGBMod";
        }
    }

    public class Q3MapRGBModScale : Q3MapRGBMod
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapRGBModScale(float red, float green, float blue)
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

    public class Q3MapRGBModSet : Q3MapRGBMod
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Q3MapRGBModSet(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return base.ToString() + " set ( " + this.Red + " " + this.Green + " " + this.Blue + " )"; ;
        }
    }

    public class Q3MapRGBModVolume : Q3MapRGBMod
    {
        public override string ToString()
        {
            return base.ToString() + " volume"; ;
        }
    }
}

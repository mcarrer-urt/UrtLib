namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapAlphaMod: Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_alphaMod";
        }
    }

    public class Q3MapAlphaModDotProduct : Q3MapAlphaMod
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Q3MapAlphaModDotProduct(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return base.ToString() + " dotProduct ( " + this.X + " " + this.Y + " " + this.Z + " )";
        }
    }

    public class Q3MapAlphaModDotProduct2 : Q3MapAlphaMod
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Q3MapAlphaModDotProduct2(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return base.ToString() + " dotProduct2 ( " + this.X + " " + this.Y + " " + this.Z + " )";
        }
    }

    public class Q3MapAlphaModScale : Q3MapAlphaMod
    {
        public float Norm { get; set; }

        public Q3MapAlphaModScale(float norm)
        {
            this.Norm = norm;
        }

        public override string ToString()
        {
            return base.ToString() + " scale " + this.Norm;
        }
    }

    public class Q3MapAlphaModSet : Q3MapAlphaMod
    {
        public float Norm { get; set; }

        public Q3MapAlphaModSet(float norm)
        {
            this.Norm = norm;
        }

        public override string ToString()
        {
            return base.ToString() + " set " + this.Norm;
        }
    }

    public class Q3MapAlphaModVolume : Q3MapAlphaMod
    {

        public override string ToString()
        {
            return base.ToString() + " volume";
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapTcGen : Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_tcGen";
        }
    }

    public class Q3MapTcGenVector : Q3MapTcGen
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float Z1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }
        public float Z2 { get; set; }

        public Q3MapTcGenVector(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.Z1 = z1;
            this.X2 = x2;
            this.Y2 = y2;
            this.Z2 = z2;
        }

        public override string ToString()
        {
            return base.ToString() + " vector ( " + this.X1 + " " + this.Y1 + " " + this.Z1 + " ) ( " + this.X2 + " " + this.Y2 + " " + this.Z2 + " )";
        }
    }

    public class Q3MapTcGenIVector : Q3MapTcGen
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float Z1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }
        public float Z2 { get; set; }

        public Q3MapTcGenIVector(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.Z1 = z1;
            this.X2 = x2;
            this.Y2 = y2;
            this.Z2 = z2;
        }

        public override string ToString()
        {
            return base.ToString() + " iVector ( " + this.X1 + " " + this.Y1 + " " + this.Z1 + " ) ( " + this.X2 + " " + this.Y2 + " " + this.Z2 + " )";
        }
    }
}

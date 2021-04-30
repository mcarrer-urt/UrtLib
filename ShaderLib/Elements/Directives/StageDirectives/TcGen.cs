namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class TcGen: StageDirective
    {
        public override string ToString()
        {
            return "tcGen";
        }
    }

    public class TcGenBase : TcGen
    {

        public override string ToString()
        {
            return base.ToString() + " base";
        }
    }

    public class TcGenLightmap : TcGen
    {
        public override string ToString()
        {
            return base.ToString() + " lightmap";
        }
    }

    public class TcGenEnvironment : TcGen
    {
        public override string ToString()
        {
            return base.ToString() + " environment";
        }
    }

    public class TcGenVector : TcGen
    {
        public float SX { get; set; }
        public float SY { get; set; }
        public float SZ { get; set; }
        public float TX { get; set; }
        public float TY { get; set; }
        public float TZ { get; set; }

        public TcGenVector(float sX, float sY, float sZ, float tX, float tY, float tZ)
        {
            this.SX = sX;
            this.SY = sY;
            this.SZ = sZ;
            this.TX = tX;
            this.TY = tY;
            this.TZ = tZ;
        }

        public override string ToString()
        {
            return base.ToString() + " vector ( " + this.SX + " " + this.SY + " " + this.SZ + " ) ( " + this.TX + " " + this.TY + " " + this.TZ + " )";
        }
    }
}

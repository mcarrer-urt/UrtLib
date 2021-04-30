namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapAlphaGen : Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_alphaGen";
        }
    }

    public class Q3MapAlphaGenConst : Q3MapAlphaGen
    {
        public float Norm { get; set; }

        public Q3MapAlphaGenConst(float norm)
        {
            this.Norm = norm;
        }

        public override string ToString()
        {
            return base.ToString() + " const " + this.Norm;
        }
    }
}

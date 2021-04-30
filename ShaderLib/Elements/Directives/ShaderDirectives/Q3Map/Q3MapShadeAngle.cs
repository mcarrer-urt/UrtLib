namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapShadeAngle : Q3MapDirective
    {
        public float Angle { get; set; }

        public Q3MapShadeAngle(float angle)
        {
            this.Angle = angle;
        }

        public override string ToString()
        {
            return "q3map_shadeAngle " + this.Angle;
        }
    }
}

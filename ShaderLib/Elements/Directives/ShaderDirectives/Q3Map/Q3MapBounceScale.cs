namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapBounceScale : Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapBounceScale(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_bounceScale " + this.Value;
        }
    }
}

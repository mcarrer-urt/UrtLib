namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapBounce: Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapBounce(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_bounce " + this.Value;
        }
    }
}

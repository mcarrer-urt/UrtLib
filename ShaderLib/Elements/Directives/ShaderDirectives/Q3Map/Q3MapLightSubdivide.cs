namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightSubdivide : Q3MapDirective
    {
        public int Value { get; set; }

        public Q3MapLightSubdivide(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_lightSubdivide " + this.Value;
        }
    }
}

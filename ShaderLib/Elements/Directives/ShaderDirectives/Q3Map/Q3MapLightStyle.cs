namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightStyle : Q3MapDirective
    {
        public int Value { get; set; }

        public Q3MapLightStyle(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_lightStyle " + this.Value;
        }
    }
}

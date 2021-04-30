namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapOffset : Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapOffset(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_offset " + this.Value;
        }
    }
}

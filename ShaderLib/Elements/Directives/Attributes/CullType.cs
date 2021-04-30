namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class CullType
    {
        public static readonly CullType Front = new CullType("front");
        public static readonly CullType Back = new CullType("back");
        public static readonly CullType Disable = new CullType("disable");
        public static readonly CullType None = new CullType("none");

        public string Value { get; private set; }

        private CullType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

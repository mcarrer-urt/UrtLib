namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class AlphaFuncType
    {
        public static readonly AlphaFuncType GT0 = new AlphaFuncType("GT0");
        public static readonly AlphaFuncType LT128 = new AlphaFuncType("LT128");
        public static readonly AlphaFuncType GE128 = new AlphaFuncType("GE128");

        public string Value { get; private set; }

        private AlphaFuncType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

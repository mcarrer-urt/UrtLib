namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class DepthFuncType
    {
        public static readonly DepthFuncType LEqual = new DepthFuncType("lequal");
        public static readonly DepthFuncType Equal = new DepthFuncType("equal");

        public string Value { get; private set; }

        private DepthFuncType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

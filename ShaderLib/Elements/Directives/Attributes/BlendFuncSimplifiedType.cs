namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class BlendFuncSimplifiedType
    {
        public static readonly BlendFuncSimplifiedType Add = new BlendFuncSimplifiedType("add");
        public static readonly BlendFuncSimplifiedType Filter = new BlendFuncSimplifiedType("filter");
        public static readonly BlendFuncSimplifiedType Blend = new BlendFuncSimplifiedType("blend");

        public string Value { get; private set; }

        private BlendFuncSimplifiedType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

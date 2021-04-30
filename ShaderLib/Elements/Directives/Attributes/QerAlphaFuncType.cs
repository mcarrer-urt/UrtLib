namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class QerAlphaFuncType
    {
        public static readonly QerAlphaFuncType Greater = new QerAlphaFuncType("greater");
        public static readonly QerAlphaFuncType Less = new QerAlphaFuncType("less");
        public static readonly QerAlphaFuncType GEqual = new QerAlphaFuncType("gequal");

        public QerAlphaFuncType(string value)
        {
            this.Value = value;
        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return this.Value;
        }

    }
}

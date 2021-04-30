namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class BlendFuncExplicitDestType
    {
        public static readonly BlendFuncExplicitDestType GL_ONE = new BlendFuncExplicitDestType("GL_ONE");
        public static readonly BlendFuncExplicitDestType GL_ZERO = new BlendFuncExplicitDestType("GL_ZERO");
        public static readonly BlendFuncExplicitDestType GL_SRC_COLOR = new BlendFuncExplicitDestType("GL_SRC_COLOR");
        public static readonly BlendFuncExplicitDestType GL_ONE_MINUS_SRC_COLOR = new BlendFuncExplicitDestType("GL_ONE_MINUS_SRC_COLOR");
        public static readonly BlendFuncExplicitDestType GL_ONE_MINUS_SRC_ALPHA = new BlendFuncExplicitDestType("GL_ONE_MINUS_SRC_ALPHA");
        public static readonly BlendFuncExplicitDestType GL_SRC_ALPHA = new BlendFuncExplicitDestType("GL_SRC_ALPHA");
        public static readonly BlendFuncExplicitDestType GL_ONE_MINUS_DST_ALPHA = new BlendFuncExplicitDestType("GL_ONE_MINUS_DST_ALPHA");

        public string Value { get; private set; }

        private BlendFuncExplicitDestType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

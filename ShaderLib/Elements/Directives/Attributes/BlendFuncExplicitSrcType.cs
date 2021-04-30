namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class BlendFuncExplicitSrcType
    {
        public static readonly BlendFuncExplicitSrcType GL_ONE = new BlendFuncExplicitSrcType("GL_ONE");
        public static readonly BlendFuncExplicitSrcType GL_ZERO = new BlendFuncExplicitSrcType("GL_ZERO");
        public static readonly BlendFuncExplicitSrcType GL_DST_COLOR = new BlendFuncExplicitSrcType("GL_DST_COLOR");
        public static readonly BlendFuncExplicitSrcType GL_ONE_MINUS_DST_COLOR = new BlendFuncExplicitSrcType("GL_ONE_MINUS_DST_COLOR");
        public static readonly BlendFuncExplicitSrcType GL_SRC_ALPHA = new BlendFuncExplicitSrcType("GL_SRC_ALPHA");
        public static readonly BlendFuncExplicitSrcType GL_ONE_MINUS_SRC_ALPHA = new BlendFuncExplicitSrcType("GL_ONE_MINUS_SRC_ALPHA");

        public string Value { get; private set; }

        private BlendFuncExplicitSrcType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

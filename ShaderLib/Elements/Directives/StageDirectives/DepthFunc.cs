using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public class DepthFunc: StageDirective
    {
        public DepthFuncType Type { get; set; }

        public DepthFunc(DepthFuncType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return "depthFunc " + this.Type;
        }
    }
}

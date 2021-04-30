using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public class AlphaFunc : StageDirective
    {
        public AlphaFuncType Type { get; set; }

        public AlphaFunc(AlphaFuncType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return "alphaFunc " + this.Type.Value;
        }
    }

}

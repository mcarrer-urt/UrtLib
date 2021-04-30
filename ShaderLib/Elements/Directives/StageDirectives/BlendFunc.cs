using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class BlendFunc : StageDirective
    {
        public override string ToString()
        {
            return "blendFunc";
        }
    }

    public class BlendFuncSimplified : BlendFunc
    {
        public BlendFuncSimplifiedType Type { get; set; }

        public BlendFuncSimplified(BlendFuncSimplifiedType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Type;
        }
    }

    public class BlendFuncExplicit : BlendFunc
    {
        public BlendFuncExplicitSrcType Source { get; set; }
        public BlendFuncExplicitDestType Destination { get; set; }

        public BlendFuncExplicit(BlendFuncExplicitSrcType source, BlendFuncExplicitDestType destination)
        {
            this.Source = source;
            this.Destination = destination;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Source + " " + this.Destination;
        }
    }
}

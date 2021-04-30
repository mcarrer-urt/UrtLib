using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class SurfaceParm: GeneralDirective
    {
        public SurfaceParmType Type { get; set; }

        public SurfaceParm(SurfaceParmType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return "surfaceParm " + this.Type;
        }

    }
}

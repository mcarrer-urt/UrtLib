using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class Cull : GeneralDirective
    {
        public CullType Side { get; set; }

        public Cull()
        {
            this.Side = CullType.Back;
        }

        public Cull(CullType side)
        {
            this.Side = side;
        }

        public override string ToString()
        {
            return "cull " + this.Side;
        }
    }
}

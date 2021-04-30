using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapLightmapAxis: Q3MapDirective
    {
        public Q3MapLightmapAxisType Axis { get; set; }

        public Q3MapLightmapAxis(Q3MapLightmapAxisType axis)
        {
            this.Axis = axis;
        }

        public override string ToString()
        {
            return "q3map_lightmapAxis " + this.Axis;
        }
    }
}

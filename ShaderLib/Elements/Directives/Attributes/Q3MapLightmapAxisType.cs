namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class Q3MapLightmapAxisType
    {
        public static readonly Q3MapLightmapAxisType X = new Q3MapLightmapAxisType("x");
        public static readonly Q3MapLightmapAxisType Y = new Q3MapLightmapAxisType("y");
        public static readonly Q3MapLightmapAxisType Z = new Q3MapLightmapAxisType("z");


        public Q3MapLightmapAxisType(string axis)
        {
            this.Axis = axis;
        }

        public string Axis { get; private set; }

        public override string ToString()
        {
            return this.Axis;
        }

    }
}

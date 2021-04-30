namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapSurfaceLight : Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapSurfaceLight(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_surfaceLight " + this.Value;
        }
    }
}

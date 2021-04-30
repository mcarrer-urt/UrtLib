namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapVertexScale : Q3MapDirective
    {
        public float Value { get; set; }

        public Q3MapVertexScale(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "q3map_vertexScale " + this.Value;
        }
    }
}

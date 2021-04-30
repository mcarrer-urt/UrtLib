namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapFogDir: Q3MapDirective
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Q3MapFogDir(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return "q3map_fogDir " + this.X + " " + this.Y + " " + this.Z;
        }
    }
}

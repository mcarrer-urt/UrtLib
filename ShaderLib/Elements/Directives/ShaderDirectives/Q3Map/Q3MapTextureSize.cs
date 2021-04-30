namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapTextureSize : Q3MapDirective
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Q3MapTextureSize(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "q3map_textureSize " + this.X + " " + this.Y;
        }
    }
}

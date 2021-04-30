namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class FogParms : GeneralDirective
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Opacity { get; set; }

        public FogParms(float red, float green, float blue, float opacity)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Opacity = opacity;
        }

        public override string ToString()
        {
            return "fogParms ( " + this.Red + " " + this.Green + " " + this.Blue + " ) " + this.Opacity;
        }
    }
}

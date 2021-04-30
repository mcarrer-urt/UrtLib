namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapBackSplash: Q3MapDirective
    {
        public float Percentage { get; set; }
        public float Distance { get; set; }

        public Q3MapBackSplash(float percentage, float distance)
        {
            this.Percentage = percentage;
            this.Distance = distance;
        }

        public override string ToString()
        {
            return "q3map_backSplash " + this.Percentage + " " + this.Distance;
        }
    }
}

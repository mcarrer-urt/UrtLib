namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapSkyLight : Q3MapDirective
    {
        public float Amount { get; set; }
        public float Iterations { get; set; }

        public Q3MapSkyLight(float amount, float iterations)
        {
            this.Amount = amount;
            this.Iterations = iterations;
        }

        public override string ToString()
        {
            return "q3map_skyLight " + this.Amount + " " + this.Iterations;
        }
    }
}

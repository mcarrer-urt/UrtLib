namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapTessSize : Q3MapDirective
    {
        public float Amount { get; set; }

        public Q3MapTessSize(float amount)
        {
            this.Amount = amount;
        }

        public override string ToString()
        {
            return "q3map_tessSize " + this.Amount;
        }
    }
}

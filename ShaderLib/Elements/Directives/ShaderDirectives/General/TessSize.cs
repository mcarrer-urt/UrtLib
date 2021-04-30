namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class TessSize : GeneralDirective
    {
        public float Amount { get; set; }

        public TessSize(float amount)
        {
            this.Amount = amount;
        }

        public override string ToString()
        {
                return "tessSize " + this.Amount;
        }
    }
}

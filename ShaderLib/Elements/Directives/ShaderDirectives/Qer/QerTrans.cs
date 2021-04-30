namespace ShaderLib.Elements.Directives.ShaderDirectives.Qer
{
    public class QerTrans: QerDirective
    {
        public float Value { get; set; }

        public QerTrans(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "qer_trans " + this.Value;
        }
    }
}

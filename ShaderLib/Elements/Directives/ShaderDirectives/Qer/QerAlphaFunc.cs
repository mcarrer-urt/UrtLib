using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.Qer
{
    public class QerAlphaFunc : QerDirective
    {
        public QerAlphaFuncType Type { get; set; }
        public float Value { get; set; }

        public QerAlphaFunc(QerAlphaFuncType type, float value)
        {
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            return "qer_alphaFunc " + this.Type + " " + this.Value;
        }
    }
}

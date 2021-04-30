namespace ShaderLib.Elements.Directives.ShaderDirectives.Qer
{
    public class QerEditorImage: QerDirective
    {
        public string TextureName { get; set; }

        public QerEditorImage(string textureName)
        {
            this.TextureName = textureName;
        }

        public override string ToString()
        {
            return "qer_editorImage \"" + this.TextureName + '\"';
        }
    }
}

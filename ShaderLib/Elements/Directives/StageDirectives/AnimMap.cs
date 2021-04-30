using System.Collections.Generic;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public class AnimMap : StageDirective
    {
        public float Frequency { get; set; }
        public List<string> TextureNames { get; set; }

        public AnimMap(float frequency, List<string> textureNames)
        {
            this.Frequency = frequency;
            this.TextureNames = textureNames;
        }

        public override string ToString()
        {
            return "animMap " + this.Frequency + " \"" + string.Join("\" \"", this.TextureNames.ToArray()) + "\"";
        }
    }
}

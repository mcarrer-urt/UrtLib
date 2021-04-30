namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class Map: StageDirective
    {
        public override string ToString()
        {
            return "map";
        }
    }

    public class MapTexture : Map
    {
        public string TextureName { get; set; }

        public MapTexture(string textureName)
        {
            this.TextureName = textureName;
        }

        public override string ToString()
        {
            return base.ToString() + " \"" + this.TextureName + '\"';
        }
    }

    public class MapLightmap : Map
    {
        public override string ToString()
        {
            return base.ToString() + " $lightmap";
        }
    }

    public class MapWhiteImage : Map
    {
        public override string ToString()
        {
            return base.ToString() + " $whiteimage";
        }
    }

}

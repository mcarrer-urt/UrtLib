namespace ShaderLib.Elements.Directives.StageDirectives
{
    public class VideoMap : StageDirective
    {
        public string VideoName { get; set; }

        public VideoMap(string videoName)
        {
            this.VideoName = videoName;
        }

        public override string ToString()
        {
            return "videoMap \"" + this.VideoName + '\"';
        }
    }
}

namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class SkyParms : GeneralDirective
    {
        public string FarBox { get; set; }
        public float CloudHeight { get; set; }
        public string NearBox { get; set; }

        public static string[] Suffixes = { "_ft", "_lf", "_rt", "_bk", "_up", "_dn" };

        public SkyParms(string farBox, float cloudHeight, string nearBox)
        {
            this.FarBox = farBox;
            this.CloudHeight = cloudHeight;
            this.NearBox = nearBox;
        }

        public override string ToString()
        {
            return "skyParms " + (this.FarBox != null ? "\"" + this.FarBox + "\"" : "-") + " " + this.CloudHeight + " " + (this.NearBox != null ? " \"" + this.NearBox + '\"' : "-");
        }
    }

}

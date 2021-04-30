namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapSurfaceModel : Q3MapDirective
    {
        public string ModelPath { get; set; }
        public float Density { get; set; }
        public float Odds { get; set; }
        public float MinScale { get; set; }
        public float MaxScale { get; set; }
        public float MinAngle { get; set; }
        public float MaxAngle { get; set; }
        public bool Oriented { get; set; }

        public Q3MapSurfaceModel(string modelPath, float density, float odds, float minScale, float maxScale, float minAngle, float maxAngle, bool oriented)
        {
            this.ModelPath = modelPath;
            this.Density = density;
            this.Odds = odds;
            this.MinScale = minScale;
            this.MaxScale = maxScale;
            this.MinAngle = minAngle;
            this.MaxAngle = maxAngle;
            this.Oriented = oriented;
        }

        public override string ToString()
        {
            return "q3map_surfaceModel \"" + this.ModelPath + "\" " + this.Density + " " + this.Odds + " " + this.MinScale + " " + this.MaxScale + " " + this.MinAngle + " " + this.MaxAngle + " " + (this.Oriented ? "1" : "0");
        }

    }
}

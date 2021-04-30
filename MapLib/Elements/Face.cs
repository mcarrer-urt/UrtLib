using MapLib.Geometry;

namespace MapLib.Elements
{
    public class Face
    {
        public Plane Plane { get; set; }
        public string Texture { get; set; } = "NULL";
        public double XOffset { get; set; } = 0;
        public double YOffset { get; set; } = 0;
        public double Rotation { get; set; } = 0;
        public double XScale { get; set; } = 0.5;
        public double YScale { get; set; } = 0.5;
        public int ContentFlags { get; set; } = 0;
        public int SurfaceFlags { get; set; } = 0;
        public double Unknown { get; set; } = 0;

        public Face(Plane plane)
        {
            this.Plane = plane;
        }

        public Face(Point3D p1, Point3D p2, Point3D p3) :
            this(new Plane(p1, p2, p3))
        {
        }

        public Face(Point3D p1, Point3D p2, Point3D p3, string texture):
            this(p1, p2, p3)
        {
            this.Texture = texture;
        }

        public override string ToString()
        {
            return string.Format("( {0} {1} {2} ) ( {3} {4} {5} ) ( {6} {7} {8} ) {9} {10} {11} {12} {13} {14} {15} {16} {17}", Plane.Point1.X, Plane.Point1.Y, Plane.Point1.Z, Plane.Point2.X, Plane.Point2.Y, Plane.Point2.Z, Plane.Point3.X, Plane.Point3.Y, Plane.Point3.Z, string.IsNullOrEmpty(Texture) ? "NULL" : Texture, XOffset, YOffset, Rotation, XScale, YScale, ContentFlags, SurfaceFlags, Unknown);
        }
    }
}

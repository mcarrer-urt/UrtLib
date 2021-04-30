using MapLib.Geometry;

namespace MapLib.Elements
{
    public class Plane
    {
        public Point3D Point1 { get; set; }
        public Point3D Point2 { get; set; }
        public Point3D Point3 { get; set; }
        
        public Plane(Point3D pt1, Point3D pt2, Point3D pt3)
        {
            this.Point1 = pt1;
            this.Point2 = pt2;
            this.Point3 = pt3;
        }
    }
}

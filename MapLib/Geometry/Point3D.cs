using System;

namespace MapLib.Geometry
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D() { }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double GetDistanceFromPoint(Point3D p)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2) + Math.Pow(Z - p.Z, 2)));
        }

        public override string ToString()
        {
            Func<double, string> formatNumber = (num) =>
            {
                var v = String.Format("{0:F}", num);
                return v;
            };

            return string.Format("( {0} {1} {2} )", formatNumber(X), formatNumber(Y), formatNumber(Z));
        }
    }
}

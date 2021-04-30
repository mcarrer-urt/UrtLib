namespace MapLib.Geometry
{
    public class Rectangle3D
    {
        public Point3D Location { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }


        public Rectangle3D()
        {
            this.Location = new Point3D();
        }

        public Rectangle3D(double width, double length, double height)
            : this()
        {
            this.Width = width;
            this.Length = length;
            this.Height = height;
        }

        public Rectangle3D(Point3D location, double width, double length, double height)
            : this(width, length, height)
        {
            this.Location = location;
        }
    }
}

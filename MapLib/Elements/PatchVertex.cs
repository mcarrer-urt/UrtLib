using System;

namespace MapLib.Elements
{
    public class PatchVertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double TextureCoordX { get; set; }
        public double TextureCoordY { get; set; }

        public override string ToString()
        {
            Func<double, string> formatNumber = (num) =>
            {
                var v = String.Format("{0:F}", num);
                return v;
            };

            return string.Format(" ( {0} {1} {2} {3} {4} ) ", formatNumber(X), formatNumber(Y), formatNumber(Z), this.TextureCoordX, this.TextureCoordY);
        }
    }
}

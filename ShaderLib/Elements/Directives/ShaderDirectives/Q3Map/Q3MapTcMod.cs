namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public abstract class Q3MapTcMod: Q3MapDirective
    {
        public override string ToString()
        {
            return "q3map_tcMod";
        }
    }

    public class Q3MapTcModRotate : Q3MapTcMod
    {
        public float Degrees { get; set; }

        public Q3MapTcModRotate(float degrees)
        {
            this.Degrees = degrees;
        }

        public override string ToString()
        {
            return base.ToString() + " rotate " + this.Degrees;
        }
    }

    public class Q3MapTcModScale : Q3MapTcMod
    {
        public float SScale { get; set; }
        public float TScale { get; set; }

        public Q3MapTcModScale(float sScale, float tScale)
        {
            this.SScale = sScale;
            this.TScale = tScale;
        }

        public override string ToString()
        {
            return base.ToString() + " scale " + this.SScale + " " + this.TScale;
        }
    }

    public class Q3MapTcModTranslate : Q3MapTcMod
    {
        public float SOffset { get; set; }
        public float TOffset { get; set; }

        public Q3MapTcModTranslate(float sOffset, float tOffset)
        {
            this.SOffset = sOffset;
            this.TOffset = tOffset;
        }

        public override string ToString()
        {
            return base.ToString() + " translate " + this.SOffset + " " + this.TOffset;
        }
    }

    public class Q3MapTcModMove : Q3MapTcMod
    {
        public float SOffset { get; set; }
        public float TOffset { get; set; }

        public Q3MapTcModMove(float sOffset, float tOffset)
        {
            this.SOffset = sOffset;
            this.TOffset = tOffset;
        }

        public override string ToString()
        {
            return base.ToString() + " move " + this.SOffset + " " + this.TOffset;
        }
    }

    public class Q3MapTcModShift : Q3MapTcMod
    {
        public float SOffset { get; set; }
        public float TOffset { get; set; }

        public Q3MapTcModShift(float sOffset, float tOffset)
        {
            this.SOffset = sOffset;
            this.TOffset = tOffset;
        }

        public override string ToString()
        {
            return base.ToString() + " shift " + this.SOffset + " " + this.TOffset;
        }
    }

}

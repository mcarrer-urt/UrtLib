using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class TcMod : StageDirective
    {
        public override string ToString()
        {
            return "tcMod";
        }
    }

    public class TcModRotate : TcMod
    {
        public float Value { get; set; }

        public TcModRotate(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return base.ToString() + " rotate " + this.Value;
        }
    }

    public class TcModScale : TcMod
    {
        public float SScale { get; set; }
        public float TScale { get; set; }

        public TcModScale(float sScale, float tScale)
        {
            this.SScale = sScale;
            this.TScale = tScale;
        }

        public override string ToString()
        {
            return base.ToString() + " scale " + this.SScale + " " + this.TScale;
        }
    }

    public class TcModScroll : TcMod
    {
        public float SSpeed { get; set; }
        public float TSpeed { get; set; }

        public TcModScroll(float sSpeed, float tSpeed)
        {
            this.SSpeed = sSpeed;
            this.TSpeed = tSpeed;
        }

        public override string ToString()
        {
            return base.ToString() + " scroll " + this.SSpeed + " " + this.TSpeed;
        }
    }

    public class TcModStretch : TcMod
    {
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public TcModStretch(WaveFormFunctionType function, float _base, float amplitude, float phase, float frequency)
        {
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " stretch " + this.Function  + " " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }

    public class TcModTransform : TcMod
    {
        public float M00 { get; set; }
        public float M01 { get; set; }
        public float M10 { get; set; }
        public float M11 { get; set; }
        public float T0 { get; set; }
        public float T1 { get; set; }

        public TcModTransform(float m00, float m01, float m10, float m11, float t0, float t1)
        {
            this.M00 = m00;
            this.M01 = m01;
            this.M10 = m10;
            this.M11 = m11;
            this.T0 = t0;
            this.T1 = t1;
        }

        public override string ToString()
        {
            return base.ToString() + " transform " + this.M00 + " " + this.M01 + " " + this.M10 + " " + this.M11 + " " + this.T0 + " " + this.T1;
        }
    }

    public class TcModTurb : TcMod
    {
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public TcModTurb(float b, float amplitude, float phase, float frequency)
        {
            this.Base = b;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " turb " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }




}

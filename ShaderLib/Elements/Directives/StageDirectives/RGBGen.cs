using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class RGBGen : StageDirective
    {
        public override string ToString()
        {
            return "RGBGen";
        }
    }

    public class RGBGenIdentity : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " identity";
        }
    }

    public class RGBGenIdentityLighting : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " identityLighting";
        }
    }

    public class RGBGenVertex : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " vertex";
        }
    }

    public class RGBGenOneMinusVertex : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " oneMinusVertex";
        }
    }

    public class RGBGenExactVertex : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " exactVertex";
        }
    }

    public class RGBGenFromVertex : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " fromVertex";
        }
    }

    public class RGBGenEntity : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " entity";
        }
    }

    public class RGBGenOneMinusEntity : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " oneMinusEntity";
        }
    }

    public class RGBGenLightingDiffuse : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " lightingDiffuse";
        }
    }

    public class RGBGenNoise : RGBGen
    {
        public override string ToString()
        {
            return base.ToString() + " noise";
        }
    }

    public class RGBGenWave : RGBGen
    {
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public RGBGenWave(WaveFormFunctionType function, float _base, float amplitude, float phase, float frequency)
        {
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " wave " + this.Function +  " " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }

    public class RGBGenConst : RGBGen
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public RGBGenConst(float red, float green, float blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString()
        {
            return base.ToString() + " const ( " + this.Red + " " + this.Green + " " + this.Blue + " )";
        }
    }
}

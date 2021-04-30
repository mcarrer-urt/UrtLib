using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.StageDirectives
{
    public abstract class AlphaGen: StageDirective
    {
        public override string ToString()
        {
            return "alphaGen";
        }
    }

    public class AlphaGenLightingSpecular : AlphaGen
    {
        public override string ToString()
        {
            return base.ToString() + " lightingSpecular";
        }
    }



    public class AlphaGenWave : AlphaGen
    {
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public AlphaGenWave(WaveFormFunctionType function, float _base, float amplitude, float phase, float frequency)
        {
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " wave " + this.Function + " " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }

    public class AlphaGenEntity : AlphaGen
    {
        public override string ToString()
        {
            return base.ToString() + " entity";
        }
    }

    public class AlphaGenOneMinusEntity : AlphaGen
    {
        public override string ToString()
        {
            return base.ToString() + " oneMinusEntity";
        }
    }

    public class AlphaGenVertex : AlphaGen
    {
        public override string ToString()
        {
            return base.ToString() + " vertex";
        }
    }

    public class AlphaGenOneMinusVertex : AlphaGen
    {
        public override string ToString()
        {
            return base.ToString() + " oneMinusVertex";
        }
    }

    public class AlphaGenConst : AlphaGen
    {
        public float Value { get; set; }

        public AlphaGenConst(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return base.ToString() + " const " + this.Value;
        }
    }

    public class AlphaGenPortal : AlphaGen
    {
        public float Value { get; set; }

        public AlphaGenPortal(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return base.ToString() + " portal " + this.Value;
        }
    }

}

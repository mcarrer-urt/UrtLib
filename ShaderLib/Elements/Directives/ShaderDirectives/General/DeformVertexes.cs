using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public abstract class DeformVertexes : GeneralDirective
    {
        public override string ToString()
        {
            return "deformVertexes";
        }
    }

    public class DeformVertexesWave : DeformVertexes
    {
        public float Div { get; set; }
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public DeformVertexesWave(float div, WaveFormFunctionType function, float _base, float amplitude, float phase, float frequency)
        {
            this.Div = div;
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " wave " + this.Div + " " + this.Function.Value + " " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }

    public class DeformVertexesNormal : DeformVertexes
    {
        public float Div { get; set; }
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Frequency { get; set; }

        public DeformVertexesNormal(float div, WaveFormFunctionType function, float _base, float amplitude, float frequency)
        {
            this.Div = div;
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            if (this.Function != null)
                return base.ToString() + " normal " + this.Div + " " + this.Function.Value + " " + this.Base + " " + this.Amplitude + " " + this.Frequency;
            else
                return base.ToString() + " normal " + this.Amplitude + " " + this.Frequency;
        }
    }

    public class DeformVertexesBulge : DeformVertexes
    {
        public float BulgeS { get; set; }
        public float BulgeT { get; set; }
        public float BulgeSpeed { get; set; }

        public DeformVertexesBulge(float bulgeS, float bulgeT, float bulgeSpeed)
        {
            this.BulgeS = bulgeS;
            this.BulgeT = bulgeT;
            this.BulgeSpeed = bulgeSpeed;
        }

        public override string ToString()
        {
            return base.ToString() + " bulge " + this.BulgeS + " " + this.BulgeT + " " + this.BulgeSpeed;
        }
    }

    public class DeformVertexesMove : DeformVertexes
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public WaveFormFunctionType Function { get; set; }
        public float Base { get; set; }
        public float Amplitude { get; set; }
        public float Phase { get; set; }
        public float Frequency { get; set; }

        public DeformVertexesMove(float x, float y, float z, WaveFormFunctionType function, float _base, float amplitude, float phase, float frequency)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Function = function;
            this.Base = _base;
            this.Amplitude = amplitude;
            this.Phase = phase;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + " move " + this.X + " " + this.Y + " " + this.Z + " " + this.Function.Value + " " + this.Base + " " + this.Amplitude + " " + this.Phase + " " + this.Frequency;
        }
    }

    public class DeformVertexesAutoSprite : DeformVertexes
    {
        public override string ToString()
        {
            return base.ToString() + " autoSprite";
        }
    }

    public class DeformVertexesAutoSprite2 : DeformVertexes
    {
        public override string ToString()
        {
            return base.ToString() + " autoSprite2";
        }
    }

    public class DeformVertexesText : DeformVertexes
    {
        public int Number { get; set; }

        public DeformVertexesText(int number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return base.ToString() + " text" + this.Number;
        }
    }

    public class DeformVertexesProjectionShadow : DeformVertexes
    {
        public override string ToString()
        {
            return base.ToString() + " projectionShadow";
        }
    }

}

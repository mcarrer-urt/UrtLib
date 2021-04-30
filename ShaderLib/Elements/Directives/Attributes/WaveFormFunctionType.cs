namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class WaveFormFunctionType
    {
        public static readonly WaveFormFunctionType Sin = new WaveFormFunctionType("sin");
        public static readonly WaveFormFunctionType Triangle = new WaveFormFunctionType("triangle");
        public static readonly WaveFormFunctionType Square = new WaveFormFunctionType("square");
        public static readonly WaveFormFunctionType SawTooth = new WaveFormFunctionType("sawTooth");
        public static readonly WaveFormFunctionType InverseSawTooth = new WaveFormFunctionType("inverseSawTooth");
        public static readonly WaveFormFunctionType Noise = new WaveFormFunctionType("noise");


        public string Value { get; private set; }

        private WaveFormFunctionType(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class SortType
    {
        public static readonly SortType Portal = new SortType(1, "portal");
        public static readonly SortType Sky = new SortType(2, "sky");
        public static readonly SortType Opaque = new SortType(3, "opaque");
        public static readonly SortType Banner = new SortType(6, "banner");
        public static readonly SortType UnderWater = new SortType(8, "underWater");
        public static readonly SortType Additive = new SortType(9, "additive");
        public static readonly SortType Nearest = new SortType(16, "nearest");


        public int Number { get; private set; }
        public string Value { get; private set; }

        private SortType(int number, string value)
        {
            this.Number = number;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
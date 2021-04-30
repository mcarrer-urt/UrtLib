using ShaderLib.Elements.Directives.Attributes;

namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class Sort : GeneralDirective
    {
        public SortType Type { get; set; }
        public int Number { get; set; }

        public Sort(SortType type)
        {
            this.Type = type;
        }

        public Sort(int number)
        {
            switch (number)
            {
                case 1: this.Type = SortType.Portal;
                    break;
                case 2: this.Type = SortType.Sky;
                    break;
                case 3: this.Type = SortType.Opaque;
                    break;
                case 6: this.Type = SortType.Banner;
                    break;
                case 8: this.Type = SortType.UnderWater;
                    break;
                case 9: this.Type = SortType.Additive;
                    break;
                case 16: this.Type = SortType.Nearest;
                    break;
                default: this.Number = number;
                    break;
            }
        }

        public override string ToString()
        {
            if (this.Type == null)
                return "sort " + this.Number;
            else
                return "sort " + this.Type;
        }
    }
}

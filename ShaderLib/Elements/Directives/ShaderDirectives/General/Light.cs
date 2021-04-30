namespace ShaderLib.Elements.Directives.ShaderDirectives.General
{
    public class Light : GeneralDirective
    {
        public int Number { get; set; }

        public Light(int number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return "light " + this.Number;
        }
    }
}

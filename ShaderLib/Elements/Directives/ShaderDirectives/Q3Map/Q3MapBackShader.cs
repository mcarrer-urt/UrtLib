namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapBackShader: Q3MapDirective
    {
        public string ShaderName { get; set; }

        public Q3MapBackShader(string shaderName)
        {
            this.ShaderName = shaderName;
        }

        public override string ToString()
        {
            return "q3map_backShader \"" + this.ShaderName + "\"";
        }
    }
}

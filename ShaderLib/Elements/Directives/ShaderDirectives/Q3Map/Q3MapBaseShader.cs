namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapBaseShader: Q3MapDirective
    {
        public string ShaderName { get; set; }

        public Q3MapBaseShader(string shaderName)
        {
            this.ShaderName = shaderName;
        }

        public override string ToString()
        {
            return "q3map_baseShader \"" + this.ShaderName + "\"";
        }
    }
}

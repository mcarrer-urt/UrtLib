namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapCloneShader: Q3MapDirective
    {
        public string ShaderName { get; set; }

        public Q3MapCloneShader(string shaderName)
        {
            this.ShaderName = shaderName;
        }

        public override string ToString()
        {
            return "q3map_cloneShader \"" + this.ShaderName + "\"";
        }
    }
}

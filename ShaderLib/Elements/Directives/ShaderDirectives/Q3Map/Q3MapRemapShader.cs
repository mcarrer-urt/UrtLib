namespace ShaderLib.Elements.Directives.ShaderDirectives.Q3Map
{
    public class Q3MapRemapShader: Q3MapDirective
    {
        public string ShaderName { get; set; }

        public Q3MapRemapShader(string shaderName)
        {
            this.ShaderName = shaderName;
        }

        public override string ToString()
        {
            return "q3map_remapShader \"" + this.ShaderName + '\"';
        }
    }
}

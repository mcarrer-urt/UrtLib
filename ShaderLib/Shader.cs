using System;
using System.Collections.Generic;
using System.Linq;
using ShaderLib.Elements;
using ShaderLib.Elements.Directives;

namespace ShaderLib
{
    public class Shader
    {
        public string Name { get; set; }
        public string ParentFile { get; set; }
        public bool CompileTime { get; set; }
        public List<ShaderDirective> Directives { get; set; }
        public List<Stage> Stages { get; set; }

        public override string ToString()
        {
            string def = Name + (this.CompileTime ? ":q3map" : string.Empty);

            string directives = null;
            if (this.Directives != null)
                directives = string.Join(Environment.NewLine, this.Directives.Select(x => '\t' + x.ToString()).ToArray());

            string stages = null;
            if (this.Stages != null)
                stages = string.Join(Environment.NewLine, this.Stages.Select(x => '\t' + x.ToString().Replace(Environment.NewLine, Environment.NewLine + '\t')).ToArray());

            return def + Environment.NewLine + '{' + Environment.NewLine + ((directives != string.Empty) ? (directives + Environment.NewLine) : string.Empty) + ((stages != string.Empty) ? (stages + Environment.NewLine) : string.Empty) + '}';
        }
    }
}

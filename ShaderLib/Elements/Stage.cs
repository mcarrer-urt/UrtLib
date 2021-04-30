using System;
using System.Collections.Generic;
using System.Linq;
using ShaderLib.Elements.Directives;

namespace ShaderLib.Elements
{
    public class Stage
    {
        public List<StageDirective> Directives { get; set; }

        public override string ToString()
        {
            string directives = null;
            if (this.Directives != null)
                directives = string.Join(Environment.NewLine, this.Directives.Select(x => '\t' + x.ToString()).ToArray());

            return (directives != string.Empty) ? ('{' + Environment.NewLine + directives + Environment.NewLine + '}') : string.Empty;
        }
    }
}

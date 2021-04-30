using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShaderLib
{
    public static class ShaderWriter
    {
        public static void Write(List<Shader> shaders, string filepath)
        {
            string text = string.Join(Environment.NewLine + Environment.NewLine, shaders.Select(x => x.ToString()).ToArray()); ;
            File.WriteAllText(filepath, text, Encoding.UTF8);
        }
    }
}

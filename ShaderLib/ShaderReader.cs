using Antlr4.Runtime;
using ShaderLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ShaderLib
{
    public static class ShaderReader
    {
        public static List<Shader> Read(string filepath, BaseErrorListener errorListener = null)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ICharStream charStream = new AntlrFileStream(filepath);
            ShaderLexer lexer = new ShaderLexer(charStream);
            ShaderParser parser = new ShaderParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();

            if (errorListener != null)
                parser.AddErrorListener(errorListener);

            return parser.shaderList().value;
        }
    }
}

using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace MapLib
{
    public static class MapReader
    {
        public static Map ReadFile(string filepath, BaseErrorListener errorListener = null)
        {
            return ReadStream(new AntlrFileStream(filepath), errorListener);
        }
        public static Map ReadText(string text, BaseErrorListener errorListener = null)
        {
            return ReadStream(new AntlrInputStream(text), errorListener);
        }

        private static Map ReadStream(ICharStream charStream, BaseErrorListener errorListener)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            MapLexer lexer = new MapLexer(charStream);
            MapParser parser = new MapParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();

            if (errorListener != null)
                parser.AddErrorListener(errorListener);

            return parser.map().value;
        }
    }
}

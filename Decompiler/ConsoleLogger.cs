// ReSharper disable InconsistentNaming
using System;
using Cpp2IL.Core;

// https://github.com/SamboyCoding/Cpp2IL/blob/new-analysis/Cpp2IL/ConsoleLogger.cs

namespace Decompiler
{
    internal static class ConsoleLogger
    {
        private static bool LastNoNewline;

        public static void Initialize()
        {
            Logger.InfoLog += (message, source) => Write("Info", source, message);
            Logger.ErrorLog += (message, source) => Write("Fail", source, message);
        }

        internal static void Write(string level, string source, string message)
        {
            if (!LastNoNewline)
                WritePrelude(level, source);

            LastNoNewline = !message.EndsWith("\n");

            Console.Write(message);
        }

        private static void WritePrelude(string level, string source)
        {
            var message = $"[{level}] [{source}] ";

            Console.Write(message);
        }
    }
}

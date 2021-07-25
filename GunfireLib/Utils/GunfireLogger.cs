﻿using System;
using System.Linq;
using MelonLoader;

namespace GunfireLib.Utils
{
    public static class GunfireLogger
    {
        public static void Verbose(string txt)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(ConsoleColor.DarkYellow, txt);
        }

        public static void Verbose(object obj)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(ConsoleColor.DarkYellow, obj);
        }

        public static void Verbose(string txt, params object[] args)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(ConsoleColor.DarkYellow, txt + ": " + string.Join(" | ", args.Select(i => i.ToString())));
        }

        public static void Verbose(ConsoleColor color, string txt)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(color, txt);
        }

        public static void Verbose(ConsoleColor color, object obj)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(color, obj);
        }

        public static void Verbose(ConsoleColor color, string txt, params object[] args)
        {
            if (GunfireLib.verboseLog) MelonLogger.Msg(color, txt + ": " + string.Join(" | ", args.Select(i => i.ToString())));
        }
    }
}
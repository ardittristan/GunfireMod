using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GunfireLib.Utils
{
    internal static class SetupData
    {
        // ReSharper disable once InconsistentNaming
        private const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

        private static readonly List<string> ImplementedMethods = new List<string>();

        internal static void Setup()
        {
            List<Type> types = Reflection.GetTypesInNamespace("GunfireLib.Data").ToList();
            types.AddRange(Reflection.GetTypesInNamespace("GunfireLib.Data.Special").AsEnumerable());

            foreach (Type type in types)
            {
                if (type.Name.Contains("MOD") || type.Name == "Extensions" || type.Name == "<>c") continue;

                MethodInfo method = type.GetMethod("Setup", bindingFlags);

                if (method == null) continue;
                GunfireLogger.Verbose("Setting up", type.Name);
                method.Invoke(null, null);

                ImplementedMethods.Add(type.Name.ToLowerInvariant());
            }

            CheckImplemented();
        }

        private static void CheckImplemented()
        {
            IEnumerable<string> sourceMethods = GetSourceMethods();

            List<string> notImplementedMethods = sourceMethods
                .Where(method => !ImplementedMethods.Contains(method))
                .ToList();

            notImplementedMethods.ForEach(method => GunfireLogger.Verbose("Missing implementation for", method));
        }

        private static IEnumerable<string> GetSourceMethods()
        {
            // ReSharper disable once StringLiteralTypo
            Type[] types = Reflection.GetTypesInNamespace(null, "csharpdata");
            Regex rgx = new Regex(@"^[a-zA-Z0-9]+$");

            return types
                .Where(t => rgx.IsMatch(t.Name))
                .Select(t => t.Name.ToLowerInvariant());
        }
    }
}

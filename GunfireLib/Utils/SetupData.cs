using System;
using System.Reflection;

namespace GunfireLib.Utils
{
    internal static class SetupData
    {
        private static readonly BindingFlags bindingFlags =
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

        internal static void Setup()
        {
            Type[] types = Reflection.GetTypesInNamespace("GunfireLib.Data");

            foreach (Type type in types)
            {
                if (type.Name.Contains("MOD") || type.Name == "Extensions" || type.Name == "<>c") continue;

                MethodInfo method = type.GetMethod("Setup", bindingFlags);

                if (method != null)
                {
                    GunfireLogger.Verbose("Setting up", type.Name);
                    method.Invoke(null, null);
                }
            }
        }
    }
}

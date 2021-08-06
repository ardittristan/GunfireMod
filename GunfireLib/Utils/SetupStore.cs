using System;
using System.Reflection;

namespace GunfireLib.Utils
{
    internal static class SetupStore
    {
        private static readonly BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
        private static readonly Type[] types = Reflection.GetTypesInNamespace("GunfireLib.Stores");

        internal static void Setup()
        {
            foreach (Type type in types)
            {
                if (type.Name == "<>c") continue;

                MethodInfo method = type.GetMethod("Setup", bindingFlags);

                if (method != null)
                {
                    GunfireLogger.Verbose("Setting up", type.Name);
                    method.Invoke(null, null);
                }
            }
        }

        internal static void LateSetup()
        {
            foreach (Type type in types)
            {
                if (type.Name == "<>c") continue;

                MethodInfo method = type.GetMethod("LateSetup", bindingFlags);

                if (method != null)
                {
                    GunfireLogger.Verbose("Setting up", type.Name);
                    method.Invoke(null, null);
                }
            }
        }
    }
}

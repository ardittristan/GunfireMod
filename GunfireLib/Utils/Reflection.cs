using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GunfireLib.Utils
{
    public static class Reflection
    {
        public static Type[] GetTypesInNamespace(string nameSpace)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetLoadableTypes())
                .Where(t => t.IsClass && t.Namespace == nameSpace)
                .ToArray();
        }

        public static Type[] GetTypesInNamespace(string nameSpace, string assemblyName)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name == assemblyName)
                .SelectMany(t => t.GetLoadableTypes())
                .Where(t => t.IsClass && t.Namespace == nameSpace)
                .ToArray();
        }

        internal static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using UnhollowerRuntimeLib.XrefScans;
using Il2CppObject = Il2CppSystem.Object;

namespace GunfireLib.Patches
{
    [HarmonyPatch]
    class ExecEvent
    {
        [HarmonyPatch(typeof(ScriptEventManager), "ExecEvent", new Type[] { typeof(string) })]
        [HarmonyPostfix]
        public static void ExecEventBase(string __0)
        {
            MelonLogger.Msg(__0);
        }

        [HarmonyPatch(typeof(ScriptEventManager), "ExecEventByAction")]
        [HarmonyPostfix]
        public static void ExecEventByAction(string __0, Il2CppObject __1)
        {
            MelonLogger.Msg(__0);
            MelonLogger.Msg(__1);
        }

        internal static void SetupVerboseLog()
        {
            IEnumerable<MethodInfo> methods = typeof(ScriptEventManager).GetMethods().Where(method => method.Name == "ExecEvent");

            foreach (MethodInfo method in methods)
            {
                IEnumerable<XrefInstance> instances = XrefScanner.UsedBy(method);

                foreach (XrefInstance instance in instances)
                {
                    MethodBase calledMethod = instance.TryResolve();
                    if (calledMethod != null)
                    {
                        MelonLogger.Msg(method.Name + " - " + method.GetParameters().Length.ToString() + ": " + calledMethod.Name);
                    }
                }
            }
        }
    }
}

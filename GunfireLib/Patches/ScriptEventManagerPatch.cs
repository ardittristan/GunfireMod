using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GunfireLib.Stores;
using GunfireLib.Utils;
using HarmonyLib;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib.XrefScans;
using Il2CppObject = Il2CppSystem.Object;

namespace GunfireLib.Patches
{
    [HarmonyPatch]
    public static class ScriptEventManagerPatch
    {
        internal static void Setup()
        {
            if (GunfireLib.verboseLog)
            {
                SetupExecEvent();
                SetupAddEvent();
            }
        }

        private static string GenerateLogString(MethodInfo method, MethodBase calledMethod)
        {
            return "Func: " + method.Name + " | Args: " + method.GetParameters().Length.ToString() + " | Caller: " + calledMethod.Name;
        }

        #region[ExecEvent]
        [HarmonyPatch(typeof(ScriptEventManager), "ExecEvent", new Type[] { typeof(string) })]
        [HarmonyPostfix]
        static void ExecEvent(string __0)
        {
            try
            {
                ScriptEventManager.EventHandler eventHandler = ScriptEventManager.instance.m_Events[__0];

                GunfireLogger.Verbose("ExecEvent", __0, "Handler -> " + eventHandler.Method.Name);
                GunfireEvents.RaiseExecEvent(new GunfireEvents.ExecEventArgs(__0, eventHandler));
                EventStore.HandleEventStore(eventHandler.Method.Name);
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                GunfireLogger.Verbose("ExecEvent", __0);
                GunfireEvents.RaiseEmptyExecEvent(new GunfireEvents.EmptyExecEventArgs(__0));
            }
        }

        [HarmonyPatch(typeof(ScriptEventManager), "ExecEventByAction")]
        [HarmonyPostfix]
        static void ExecEventByAction(string __0, Il2CppObject __1)
        {
            try
            {
                ScriptEventManager.EventHandler eventHandler = ScriptEventManager.instance.m_Events[__0];

                GunfireLogger.Verbose("ExecEventByAction", __0, __1, "Handler -> " + eventHandler.Method.Name);
                GunfireEvents.RaiseExecEvent(new GunfireEvents.ExecEventArgs(__0, eventHandler, __1));
                EventStore.HandleEventStore(eventHandler.Method.Name);
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                GunfireLogger.Verbose("ExecEventByAction", __0, __1);
                GunfireEvents.RaiseEmptyExecEvent(new GunfireEvents.EmptyExecEventArgs(__0, __1));
            }
        }

        private static void SetupExecEvent()
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
                        GunfireLogger.Verbose(GenerateLogString(method, calledMethod));
                    }
                }
            }
        }
        #endregion

        #region[AddEvent]
        [HarmonyPatch(typeof(ScriptEventManager), "AddEvent")]
        static void AddEvent(string __0, ScriptEventManager.EventHandler __1)
        {
            GunfireLogger.Verbose("AddEvent", __0, __1);
        }

        private static void SetupAddEvent()
        {
            MethodInfo method = typeof(ScriptEventManager).GetMethod("AddEvent");

            IEnumerable<XrefInstance> instances = XrefScanner.UsedBy(method);

            foreach (XrefInstance instance in instances)
            {
                MethodBase calledMethod = instance.TryResolve();
                if (calledMethod != null)
                {
                    GunfireLogger.Verbose(GenerateLogString(method, calledMethod));
                }
            }
        }
        #endregion
    }
}

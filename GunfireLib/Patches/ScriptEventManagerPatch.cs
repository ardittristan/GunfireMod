using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FileParser;
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
        private static List<string> eventList = new List<string>();

        internal static void Setup()
        {
            if (GunfireLib.fileLog)
            {
                SetupEventStore();
            }

            if (GunfireLib.verboseLog)
            {
                SetupExecEvent();
                SetupAddEvent();
            }
        }

        #region[EventStore]
        private static void SetupEventStore()
        {
            GunfireEvents.QuitEvent += SaveEventStore;

            if (File.Exists(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt")))
            {
                IParsedFile file = new ParsedFile(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt"));
                eventList = file.ToList<string>();
            }
        }

        private static void SaveEventStore()
        {
            if (eventList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt"), eventList);
            }
        }

        private static void HandleEventStore(string func){
            if (GunfireLib.fileLog)
            {
                if (!eventList.Contains(func))
                {
                    eventList.Add(func);
                }
            }
        }
        #endregion

        private static string GenerateLogString(MethodInfo method, MethodBase calledMethod)
        {
            return "Func: " + method.Name + " | Args: " + method.GetParameters().Length.ToString() + " | Caller: " + calledMethod.Name;
        }

        #region[ExecEvent]
        [HarmonyPatch(typeof(ScriptEventManager), "ExecEvent", new Type[] { typeof(string) })]
        [HarmonyPostfix]
        public static void ExecEvent(string __0)
        {
            try
            {
                ScriptEventManager.EventHandler eventHandler = ScriptEventManager.instance.m_Events[__0];

                GunfireLogger.Verbose("ExecEvent", __0, "Handler -> " + eventHandler.Method.Name);
                GunfireEvents.RaiseExecEvent(new GunfireEvents.ExecEventArgs(__0, eventHandler));
                HandleEventStore(eventHandler.Method.Name);
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                GunfireLogger.Verbose("ExecEvent", __0);
                GunfireEvents.RaiseEmptyExecEvent(new GunfireEvents.EmptyExecEventArgs(__0));
            }
        }

        [HarmonyPatch(typeof(ScriptEventManager), "ExecEventByAction")]
        [HarmonyPostfix]
        public static void ExecEventByAction(string __0, Il2CppObject __1)
        {
            try
            {
                ScriptEventManager.EventHandler eventHandler = ScriptEventManager.instance.m_Events[__0];

                GunfireLogger.Verbose("ExecEventByAction", __0, __1, "Handler -> " + eventHandler.Method.Name);
                GunfireEvents.RaiseExecEvent(new GunfireEvents.ExecEventArgs(__0, eventHandler, __1));
                HandleEventStore(eventHandler.Method.Name);
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
        public static void AddEvent(string __0, ScriptEventManager.EventHandler __1)
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

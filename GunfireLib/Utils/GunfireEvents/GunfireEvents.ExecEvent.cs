using System;
using Il2Cpp;
using Il2CppObject = Il2CppSystem.Object;

namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public delegate void ExecEventHandler(ExecEventArgs e);
        public static event ExecEventHandler ExecEvent = delegate { };
        internal static void RaiseExecEvent(ExecEventArgs args)
        {
            ExecEvent?.Invoke(args);
        }

        public class ExecEventArgs : EventArgs
        {
            public ExecEventArgs(string eventName, ScriptEventManager.EventHandler eventHandler, Il2CppObject eventParam = null)
            {
                Event = eventName;
                EventHandler = eventHandler;
                EventParam = eventParam;
            }
            public string Event { get; }
            public ScriptEventManager.EventHandler EventHandler { get; }
            public Il2CppObject EventParam { get; }
        }
    }
}

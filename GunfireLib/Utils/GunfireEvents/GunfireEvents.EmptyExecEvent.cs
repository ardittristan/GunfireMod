using System;
using Il2CppObject = Il2CppSystem.Object;

namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public delegate void EmptyExecEventHandler(EmptyExecEventArgs e);
        public static event EmptyExecEventHandler EmptyExecEvent = delegate { };
        internal static void RaiseEmptyExecEvent(EmptyExecEventArgs args)
        {
            EmptyExecEvent?.Invoke(args);
        }

        public class EmptyExecEventArgs : EventArgs
        {
            public EmptyExecEventArgs(string eventName, Il2CppObject eventParam = null)
            {
                Event = eventName;
                EventParam = eventParam;
            }
            public string Event { get; }
            public Il2CppObject EventParam { get; }
        }
    }
}

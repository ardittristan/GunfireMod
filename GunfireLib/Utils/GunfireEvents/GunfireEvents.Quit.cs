using System;

namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public delegate void QuitEventHandler();
        public static event QuitEventHandler QuitEvent = delegate { };
        internal static void RaiseQuitEvent()
        {
            QuitEvent?.Invoke();
        }
    }
}

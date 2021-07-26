namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public static event EmptyEventHandler QuitEvent = delegate { };
        internal static void RaiseQuitEvent()
        {
            QuitEvent?.Invoke();
        }
    }
}

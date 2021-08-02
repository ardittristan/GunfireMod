namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public static event EmptyEventHandler OnGameLoaded = delegate { };
        internal static void RaiseGameLoaded()
        {
            OnGameLoaded?.Invoke();
        }
    }
}

namespace GunfireLib.Utils
{
    public static partial class GunfireEvents
    {
        public static event EmptyEventHandler OnLateGameLoaded = delegate { };
        internal static void RaiseLateGameLoaded()
        {
            OnLateGameLoaded?.Invoke();
        }
    }
}

namespace GunfireLib.Stores
{
    internal static class SetupStore
    {
        internal static void Setup()
        {
            EventStore.Setup();
        }

        internal static void LateSetup()
        {
            MapDataStore.Setup();
            TranslationsStore.Setup();
            SpecialTranslationsStore.Setup();
            AchievementDataStore.Setup();
        }
    }
}

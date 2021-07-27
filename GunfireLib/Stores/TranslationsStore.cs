using StringList = System.Collections.Generic.List<string>;
using System.IO;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class TranslationsStore
    {
        private static readonly StringList translationList = new StringList();

        internal static void Setup()
        {
            Dictionary<string, string> translationDictionary = normaltextdata_English.GetData();

            GunfireEvents.QuitEvent += SaveTranslationStore;

            foreach (KeyValuePair<string, string> item in translationDictionary)
            {
                HandleTranslationStore(item.Key, item.Value);
            }
        }

        private static void SaveTranslationStore()
        {
            if (translationList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "translationList.txt"), translationList);
            }
        }

        private static void HandleTranslationStore(string id, string value)
        {
            string text = "[" + id + " = " + value + "]";
            if (!translationList.Contains(text))
            {
                translationList.Add(text);
            }
        }
    }
}

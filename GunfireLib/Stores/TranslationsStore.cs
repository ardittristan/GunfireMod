using StringList = System.Collections.Generic.List<string>;
using System.IO;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class TranslationsStore
    {
        private static readonly StringList TranslationList = new StringList();

        internal static void LateSetup()
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
            if (TranslationList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "translationList.txt"), TranslationList);
            }
        }

        private static void HandleTranslationStore(string id, string value)
        {
            string text = "[" + id + " = " + value + "]";
            if (!TranslationList.Contains(text))
            {
                TranslationList.Add(text);
            }
        }
    }
}

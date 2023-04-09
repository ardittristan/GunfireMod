using StringList = System.Collections.Generic.List<string>;
using System.IO;
using GunfireLib.Utils;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class SpecialTranslationsStore
    {
        private static readonly StringList SpecialTranslationList = new StringList();

        internal static void LateSetup()
        {
            Dictionary<string, string> specialTranslationDictionary = specialtextdata_English.GetData();

            GunfireEvents.QuitEvent += SaveSpecialTranslationStore;

            foreach (KeyValuePair<string, string> item in specialTranslationDictionary)
            {
                HandleSpecialTranslationStore(item.Key, item.Value);
            }
        }

        private static void SaveSpecialTranslationStore()
        {
            if (SpecialTranslationList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "specialTranslationList.txt"),
                    SpecialTranslationList);
            }
        }

        private static void HandleSpecialTranslationStore(string id, string value)
        {
            string text = "[" + id + " = " + value + "]";
            if (!SpecialTranslationList.Contains(text))
            {
                SpecialTranslationList.Add(text);
            }
        }
    }
}

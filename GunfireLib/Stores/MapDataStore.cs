using StringList = System.Collections.Generic.List<string>;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using DataHelper;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class MapDataStore
    {
        private static readonly StringList MapNameList = new StringList();
        private static readonly StringList DevMapNameList = new StringList();
        private static readonly StringList FullDevMapNameList = new StringList();

        internal static void LateSetup()
        {
            Dictionary<string, levelconfigdataclass> levelList = levelconfigdata.GetData();

            GunfireEvents.QuitEvent += SaveMapNameStore;

            foreach (KeyValuePair<string, levelconfigdataclass> item in levelList)
            {
                HandleMapNameStore(item.Value.Name,
                    string.IsNullOrWhiteSpace(item.Value.DevName) ? "" : item.Value.DevName);
            }
        }

        private static void SaveMapNameStore()
        {
            if (MapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "mapNameList.txt"), MapNameList);
            }
            if (DevMapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "devMapNameList.txt"), DevMapNameList);
            }
            if (FullDevMapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "fullDevMapNameList.txt"),
                    FullDevMapNameList);
            }
        }

        private static void HandleMapNameStore(string name, string devName)
        {
            name = "[" + name + "]";
            if (!MapNameList.Contains(name))
            {
                MapNameList.Add(name);
            }

            devName = devName.Replace("（", "(");
            devName = devName.Replace("）", ")");
            StringList devMatches = Regex.Matches(devName, "[^\x00-\x7F]+")
                                            .OfType<Match>()
                                            .Select(m => m.Groups[0].Value)
                                            .ToList();
            // ReSharper disable once InconsistentNaming
            foreach (string DevName in devMatches)
            {
                string parsedDevName = "[" + DevName + "]";
                if (!DevMapNameList.Contains(parsedDevName))
                {
                    DevMapNameList.Add(parsedDevName);
                }
            }

            devName = "[" + devName + "]";
            if (!FullDevMapNameList.Contains(devName))
            {
                FullDevMapNameList.Add(devName);
            }
        }
    }
}

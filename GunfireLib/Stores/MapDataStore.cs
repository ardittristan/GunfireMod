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
        private static readonly StringList mapNameList = new StringList();
        private static readonly StringList devMapNameList = new StringList();
        private static readonly StringList fullDevMapNameList = new StringList();

        internal static void LateSetup()
        {
            Dictionary<string, levelconfigdataclass> levelList = levelconfigdata.GetData();

            GunfireEvents.QuitEvent += SaveMapNameStore;

            foreach (KeyValuePair<string, levelconfigdataclass> item in levelList)
            {
                HandleMapNameStore(item.Value.Name, string.IsNullOrWhiteSpace(item.Value.DevName) ? "" : item.Value.DevName);
            }
        }

        private static void SaveMapNameStore()
        {
            if (mapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "mapNameList.txt"), mapNameList);
            }
            if (devMapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "devMapNameList.txt"), devMapNameList);
            }
            if (fullDevMapNameList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "fullDevMapNameList.txt"), fullDevMapNameList);
            }
        }

        private static void HandleMapNameStore(string name, string devName)
        {
            name = "[" + name + "]";
            if (!mapNameList.Contains(name))
            {
                mapNameList.Add(name);
            }

            devName = devName.Replace("（", "(");
            devName = devName.Replace("）", ")");
            StringList devMatches = Regex.Matches(devName, "[^\x00-\x7F]+")
                                            .OfType<Match>()
                                            .Select(m => m.Groups[0].Value)
                                            .ToList();
            foreach (string DevName in devMatches)
            {
                string ParsedDevName = "[" + DevName + "]";
                if (!devMapNameList.Contains(ParsedDevName))
                {
                    devMapNameList.Add(ParsedDevName);
                }
            }

            devName = "[" + devName + "]";
            if (!fullDevMapNameList.Contains(devName))
            {
                fullDevMapNameList.Add(devName);
            }
        }
    }
}

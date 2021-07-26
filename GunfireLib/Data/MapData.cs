using StringList = System.Collections.Generic.List<string>;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using DataHelper;
using FileParser;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static partial class MapData
    {
        public static Dictionary<string, levelconfigdataclass> levelList;

        private static StringList mapNameList = new StringList();
        private static StringList devMapNameList = new StringList();
        private static readonly StringList fullDevMapNameList = new StringList();

        internal static void Setup()
        {
            levelList = levelconfigdata.GetData();

            if (GunfireLib.fileLog)
            {
                SetupMapNameStore();
                foreach (KeyValuePair<string, levelconfigdataclass> item in levelList)
                {
                    HandleMapNameStore(item.Value.Name, string.IsNullOrWhiteSpace(item.Value.DevName) ? "" : item.Value.DevName);
                }
            }
        }

        #region[MapNameStore]
        private static void SetupMapNameStore()
        {
            GunfireEvents.QuitEvent += SaveMapNameStore;

            if (File.Exists(Path.Combine(GunfireLib.libConfigDirectory, "mapNameList.txt")))
            {
                IParsedFile file = new ParsedFile(Path.Combine(GunfireLib.libConfigDirectory, "mapNameList.txt"));
                mapNameList = file.ToList<string>();
            }
            if (File.Exists(Path.Combine(GunfireLib.libConfigDirectory, "devMapNameList.txt")))
            {
                IParsedFile file = new ParsedFile(Path.Combine(GunfireLib.libConfigDirectory, "devMapNameList.txt"));
                devMapNameList = file.ToList<string>();
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
            if (GunfireLib.fileLog)
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
                foreach(string DevName in devMatches)
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
        #endregion
    }
}

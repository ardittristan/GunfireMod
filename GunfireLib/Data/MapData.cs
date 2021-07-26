using StringList = System.Collections.Generic.List<string>;
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

        internal static void Setup()
        {
            levelList = levelconfigdata.GetData();

            if (GunfireLib.fileLog)
            {
                SetupMapNameStore();
                foreach (KeyValuePair<string, levelconfigdataclass> item in levelList)
                {
                    HandleMapNameStore("[" + item.Value.Name + "]", string.IsNullOrWhiteSpace(item.Value.DevName) ? "" : "[" + item.Value.DevName + "]");
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
        }

        private static void HandleMapNameStore(string name, string devName)
        {
            if (GunfireLib.fileLog)
            {
                if (!mapNameList.Contains(name))
                {
                    mapNameList.Add(name);
                }
                if (!devMapNameList.Contains(devName))
                {
                    devMapNameList.Add(devName);
                }
            }
        }
        #endregion
    }
}

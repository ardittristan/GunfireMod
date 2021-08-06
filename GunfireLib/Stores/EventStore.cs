using System.Collections.Generic;
using System.IO;
using GunfireLib.Utils;

namespace GunfireLib.Stores
{
    internal static class EventStore
    {
        private static List<string> eventList = new List<string>();

        internal static void Setup()
        {
            GunfireEvents.QuitEvent += SaveEventStore;

            if (File.Exists(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt")))
            {
                string[] file = File.ReadAllLines(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt"));
                eventList = new List<string>(file);
            }
        }

        private static void SaveEventStore()
        {
            if (eventList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt"), eventList);
            }
        }

        internal static void HandleEventStore(string func)
        {
            if (GunfireLib.fileLog)
            {
                if (!eventList.Contains(func))
                {
                    eventList.Add(func);
                }
            }
        }
    }
}

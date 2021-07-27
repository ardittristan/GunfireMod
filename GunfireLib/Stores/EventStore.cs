using System.Collections.Generic;
using System.IO;
using FileParser;
using GunfireLib.Utils;

namespace GunfireLib.Stores
{
    internal static class EventStore
    {
        private static List<string> eventList = new List<string>();

        internal static void Setup()
        {
            SetupEventStore();
        }

        private static void SetupEventStore()
        {
            GunfireEvents.QuitEvent += SaveEventStore;

            if (File.Exists(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt")))
            {
                IParsedFile file = new ParsedFile(Path.Combine(GunfireLib.libConfigDirectory, "eventList.txt"));
                eventList = file.ToList<string>();
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

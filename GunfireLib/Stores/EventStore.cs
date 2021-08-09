using System.Collections.Generic;
using System.IO;
using GunfireLib.Utils;

namespace GunfireLib.Stores
{
    internal static class EventStore
    {
        private static List<string> _eventList = new List<string>();

        internal static void Setup()
        {
            GunfireEvents.QuitEvent += SaveEventStore;

            if (File.Exists(Path.Combine(GunfireLib.LibConfigDirectory, "eventList.txt")))
            {
                string[] file = File.ReadAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "eventList.txt"));
                _eventList = new List<string>(file);
            }
        }

        private static void SaveEventStore()
        {
            if (_eventList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "eventList.txt"), _eventList);
            }
        }

        internal static void HandleEventStore(string func)
        {
            if (GunfireLib.FileLog)
            {
                if (!_eventList.Contains(func))
                {
                    _eventList.Add(func);
                }
            }
        }
    }
}

using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ObjSignal
    {
        public static Dictionary<string, objsignalclass> signalList;

        public static System.Collections.Generic.Dictionary<string, Classes.ObjSignalClass> parsedSignalList =
            new System.Collections.Generic.Dictionary<string, Classes.ObjSignalClass>();

        internal static void Setup()
        {
            signalList = objsignal.GetData();
            foreach (KeyValuePair<string, objsignalclass> signal in signalList)
            {
                parsedSignalList.Add(signal.Key, new Classes.ObjSignalClass(signal.Key, signalList));
            }
        }
    }
}
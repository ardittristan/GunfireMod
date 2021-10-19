using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ObjSignal
    {
        public static Dictionary<int, objsignalclass> signalList;

        public static System.Collections.Generic.Dictionary<int, Classes.ObjSignalClass> parsedSignalList =
            new System.Collections.Generic.Dictionary<int, Classes.ObjSignalClass>();

        internal static void Setup()
        {
            signalList = objsignal.GetData();
            foreach (KeyValuePair<int, objsignalclass> signal in signalList)
            {
                parsedSignalList.Add(signal.Key, new Classes.ObjSignalClass(signal.Key, signalList));
            }
        }
    }
}
using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class InscriptionData
    {
        public static Dictionary<int, inscriptiondataclass> inscriptionList;

        public static System.Collections.Generic.Dictionary<int, Classes.InscriptionDataClass> parsedInscriptionList =
            new System.Collections.Generic.Dictionary<int, Classes.InscriptionDataClass>();

        internal static void Setup()
        {
            inscriptionList = inscriptiondata.GetData();
            foreach (KeyValuePair<int, inscriptiondataclass> inscription in inscriptionList)
            {
                parsedInscriptionList.Add(inscription.Key, new Classes.InscriptionDataClass(inscription.Key, inscriptionList));
            }
        }
    }
}
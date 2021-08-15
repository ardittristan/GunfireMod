using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class InscriptionData
    {
        public static Dictionary<string, inscriptiondataclass> inscriptionList;

        public static System.Collections.Generic.Dictionary<string, Classes.InscriptionDataClass> parsedInscriptionList =
            new System.Collections.Generic.Dictionary<string, Classes.InscriptionDataClass>();

        internal static void Setup()
        {
            inscriptionList = inscriptiondata.GetData();
            foreach (KeyValuePair<string, inscriptiondataclass> inscription in inscriptionList)
            {
                parsedInscriptionList.Add(inscription.Key, new Classes.InscriptionDataClass(inscription.Key, inscriptionList));
            }
        }
    }
}
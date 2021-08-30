using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ModelData
    {
        public static Dictionary<string, modeldataclass> modelList;

        public static System.Collections.Generic.Dictionary<string, Classes.ModelDataClass> parsedModelList =
            new System.Collections.Generic.Dictionary<string, Classes.ModelDataClass>();

        internal static void Setup()
        {
            modelList = modeldata.GetData();
            foreach (KeyValuePair<string, modeldataclass> model in modelList)
            {
                parsedModelList.Add(model.Key, new Classes.ModelDataClass(model.Key, modelList));
            }
        }
    }
}
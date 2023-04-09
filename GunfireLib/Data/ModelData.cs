using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class ModelData
    {
        public static Dictionary<int, modeldataclass> modelList;

        public static System.Collections.Generic.Dictionary<int, Classes.ModelDataClass> parsedModelList =
            new System.Collections.Generic.Dictionary<int, Classes.ModelDataClass>();

        internal static void Setup()
        {
            modelList = modeldata.GetData();
            foreach (KeyValuePair<int, modeldataclass> model in modelList)
            {
                parsedModelList.Add(model.Key, new Classes.ModelDataClass(model.Key, modelList));
            }
        }
    }
}
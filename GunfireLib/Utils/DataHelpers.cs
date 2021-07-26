using DataHelper;

namespace GunfireLib.Utils
{
    public static class DataHelpers
    {
        public static string GetEnglishName(this levelconfigdataclass baseClass)
        {
            return baseClass.Name;
        }

        public static string GetEnglishDevName(this levelconfigdataclass baseClass)
        {
            return baseClass.DevName;
        }
    }
}

using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileWeaponData
    {
        public static Dictionary<string, itemdataclass> weaponList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedWeaponList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            weaponList = mobileweapondata.GetData();
            foreach (KeyValuePair<string, itemdataclass> weapon in weaponList)
            {
                parsedWeaponList.Add(weapon.Key, new Classes.ItemDataClass(weapon.Key, weaponList));
            }
        }
    }
}
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileWeaponData
    {
        public static Dictionary<int, itemdataclass> weaponList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedWeaponList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            weaponList = mobileweapondata.GetData();
            foreach (KeyValuePair<int, itemdataclass> weapon in weaponList)
            {
                parsedWeaponList.Add(weapon.Key, new Classes.ItemDataClass(weapon.Key, weaponList));
            }
        }
    }
}
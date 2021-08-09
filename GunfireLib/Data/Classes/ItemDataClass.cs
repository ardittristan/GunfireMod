// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using System;
using Il2CppSystem.Collections.Generic;
using DataHelper;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace GunfireLib.Data.Extensions
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this itemdataclass baseClass) =>
            Classes.ItemDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this itemdataclass baseClass) =>
            Classes.ItemDataClass.GetEnglishDesc(baseClass.Desc);

        public static string GetEnglishDetailDesc(this itemdataclass baseClass) =>
            Classes.ItemDataClass.GetEnglishDetailDesc(baseClass.DetailDesc);

        public static string GetEnglishSimpleDesc(this itemdataclass baseClass) =>
            Classes.ItemDataClass.GetEnglishSimpleDesc(baseClass.SimpleDesc);

        public static string GetEnglishUnlockDesc(this itemdataclass baseClass) =>
            Classes.ItemDataClass.GetEnglishUnlockDesc(baseClass.UnLockDesc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ItemDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, itemdataclass> attributeList;

        public ItemDataClass(string key, Dictionary<string, itemdataclass> attributeList)
        {
            this.key = key;
            this.attributeList = attributeList;
        }

        public int Accuracy
        {
            get => attributeList[key].Accuracy;
        }

        public int AdsorbRange
        {
            get => attributeList[key].AdsorbRange;
        }

        // TODO:
        public AttAutoChangeInfo AttAutoChange
        {
            get => attributeList[key].AttAutoChange;
        }

        public int AttDamage
        {
            get => attributeList[key].AttDamage;
        }

        public int AttSpeed
        {
            get => attributeList[key].AttSpeed;
        }

        // TODO:
        public Dictionary<string, SAutoAttackInfoSub> AutoAttackInfo
        {
            get => attributeList[key].AutoAttackInfo;
        }

        public int AutoReload
        {
            get => attributeList[key].AutoReload;
        }

        // TODO:
        public Dictionary<string, SBulletFlyInfoSub> BulletFlyInfo
        {
            get => attributeList[key].BulletFlyInfo;
        }

        // TODO:
        public Dictionary<string, SBulletInfoSub> BulletInfo
        {
            get => attributeList[key].BulletInfo;
        }

        public int CanAdsorb
        {
            get => attributeList[key].CanAdsorb;
        }

        public int CanDoubleHold
        {
            get => attributeList[key].CanDoubleHold;
        }

        // TODO:
        public Dictionary<string, SContinueShootInfoSub> ContinueShootInfo
        {
            get => attributeList[key].ContinueShootInfo;
        }

        public int CrazyEff
        {
            get => attributeList[key].CrazyEff;
        }

        public int DefaultLock
        {
            get => attributeList[key].DefaultLock;
        }

        public string Desc
        {
            get => attributeList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(attributeList[key].Desc);
        }

        public string DetailDesc
        {
            get => attributeList[key].DetailDesc;
        }

        public string EnglishDetailDesc
        {
            get => GetEnglishDetailDesc(attributeList[key].DetailDesc);
        }

        public List<int> DetailLabel
        {
            get => attributeList[key].DetailLabel;
        }

        public int Dropable
        {
            get => attributeList[key].Dropable;
        }

        public int DropDelay
        {
            get => attributeList[key].DropDelay;
        }

        public int DropModelID
        {
            get => attributeList[key].DropModelID;
        }

        public string DropMusicEffect
        {
            get => attributeList[key].DropMusicEffect;
        }

        public string EffectPath
        {
            get => attributeList[key].EffectPath;
        }

        // TODO:
        public Dictionary<string, ElementInfo> ElementInfo
        {
            get => attributeList[key].ElementInfo;
        }

        public float ExplosionRange
        {
            get => attributeList[key].ExplosionRange;
        }

        public int IconID
        {
            get => attributeList[key].IconID;
        }

        public int ID
        {
            get => attributeList[key].ID;
        }

        // TODO:
        public Dictionary<string, SItemSkillInfoSub> ItemSkillInfo
        {
            get => attributeList[key].ItemSkillInfo;
        }

        public int ItemType
        {
            get => attributeList[key].ItemType;
        }

        public int MaxCnt
        {
            get => attributeList[key].MaxCnt;
        }

        public string Name
        {
            get => attributeList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(attributeList[key].Name);
        }

        // TODO:
        public Dictionary<string, SOpenSnipeInfoSub> OpenSnipeInfo
        {
            get => attributeList[key].OpenSnipeInfo;
        }

        public int PutAwayTime
        {
            get => attributeList[key].PutAwayTime;
        }

        // TODO:
        public Dictionary<string, RelicDescInfo> RelicDescInfo
        {
            get => attributeList[key].RelicDescInfo;
        }

        public string RelicType
        {
            get => attributeList[key].RelicType;
        }

        public int SetMaxCnt
        {
            get => attributeList[key].SetMaxCnt;
        }

        public int Shape
        {
            get => attributeList[key].Shape;
        }

        // TODO:
        public Dictionary<string, ShopInfoInfo> ShopInfo
        {
            get => attributeList[key].ShopInfo;
        }

        public int Showable
        {
            get => attributeList[key].Showable;
        }

        // TODO:
        public Dictionary<string, ShowInfo> ShowInfo
        {
            get => attributeList[key].ShowInfo;
        }

        public string SimpleDesc
        {
            get => attributeList[key].SimpleDesc;
        }

        public string EnglishSimpleDesc
        {
            get => GetEnglishSimpleDesc(attributeList[key].SimpleDesc);
        }

        public int Stability
        {
            get => attributeList[key].Stability;
        }

        public int TakeOutTime
        {
            get => attributeList[key].TakeOutTime;
        }

        public int Trajectory
        {
            get => attributeList[key].Trajectory;
        }

        public string UnLockDesc
        {
            get => attributeList[key].UnLockDesc;
        }

        public string EnglishUnLockDesc
        {
            get => GetEnglishUnlockDesc(attributeList[key].UnLockDesc);
        }

        // TODO:
        public Dictionary<string, WeaponMusicEffect> WeaponMusic
        {
            get => attributeList[key].WeaponMusic;
        }

        public int WeaponType
        {
            get => attributeList[key].WeaponType;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return AttributeNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return AttributeDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishDetailDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return AttributeDetailDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishSimpleDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return AttributeSimpleDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishUnlockDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return AttributeUnlockDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary AttributeNames = new StringDictionary()
        {

        };

        public static RStringDictionary AttributeDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary AttributeDetailDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary AttributeSimpleDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary AttributeUnlockDescriptions = new StringDictionary()
        {

        };
    }
}


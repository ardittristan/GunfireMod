// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using System;
using Il2CppSystem.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataHelper;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace GunfireLib.Data.Extensions
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this levelconfigdataclass baseClass) =>
            Classes.LevelConfigDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDevName(this levelconfigdataclass baseClass) =>
            Classes.LevelConfigDataClass.GetEnglishDevName(baseClass.DevName);
    }
}

namespace GunfireLib.Data.Classes
{
    public class LevelConfigDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, levelconfigdataclass> levelList;

        public LevelConfigDataClass(int key, Dictionary<int, levelconfigdataclass> levelList)
        {
            this.key = key;
            this.levelList = levelList;
        }

        public int ID
        {
            get => levelList[key].ID;
        }

        public Dictionary<int, OneLevelInfo> Info
        {
            get => levelList[key].Info;
        }

        public int LevelID
        {
            get => levelList[key].LevelID;
        }

        public int ModelID
        {
            get => levelList[key].ModelID;
        }

        public string Name
        {
            get => levelList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(levelList[key].Name);
        }

        public string DevName
        {
            get => levelList[key].DevName;
        }

        public string EnglishDevName
        {
            get => GetEnglishDevName(levelList[key].DevName);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return LevelNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDevName(string devName)
        {
            if (string.IsNullOrWhiteSpace(devName)) return "";
            try
            {
                return DevLevelNames[devName];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                devName = devName.Replace("（", "(");
                devName = devName.Replace("）", ")");
                System.Collections.Generic.List<string> matches = Regex.Matches(devName, "[^\x00-\x7F]+")
                    .OfType<Match>().Select(m => m.Groups[0].Value).ToList();

                foreach (string match in matches)
                {
                    try
                    {
                        devName = devName.Replace(match, DevLevelNames[match]);
                    }
                    catch (Exception exc) when (exc is Il2CppException || exc is KeyNotFoundException)
                    {
                    }
                }

                return devName;
            }
        }

        public static RStringDictionary LevelNames = new StringDictionary()
        {
            {
                "龙陵墓穴-入口",
                "Dragon Tomb-Entrance"
            },
            {
                "幽山曲径",
                "Winding Path of the Tranquil Mountain"
            },
            {
                "龙陵墓穴-第一关",
                "Dragon Tomb-Level 1"
            },
            {
                "龙陵墓穴-第二关",
                "Dragon Tomb-Level 2"
            },
            {
                "龙陵墓穴-第三关",
                "Dragon Tomb-Level 3"
            },
            {
                "龙陵墓穴-第四关",
                "Dragon Tomb-Level 4"
            },
            {
                "龙陵墓穴-长生殿",
                "Dragon Tomb-Hall of Eternal Life"
            },
            {
                "安西大漠-入口",
                "Anxi Desert-Entrance"
            },
            {
                "安西大漠-第一关",
                "Anxi Desert-First Pass"
            },
            {
                "大漠遗址",
                "Desert ruins"
            },
            {
                "安西大漠-第二关",
                "Anxi Desert-Second Level"
            },
            {
                "安西大漠-第四关",
                "Anxi Desert-Fourth Level"
            },
            {
                "安西大漠-行刺",
                "Anxi Desert-Assassination"
            },
            {
                "安西大漠-第三关",
                "Anxi Desert-Third Level"
            },
            {
                "安西大漠-流沙泊",
                "Anxi Desert-Quicksand"
            },
            {
                "山海双屿—入口",
                "Shanhai Shuangyu—Entrance"
            },
            {
                "山海双屿-第一关",
                "Shanhai Shuangyu-First Pass"
            },
            {
                "山海双屿-第二关",
                "Shanhai Shuangyu-Second Pass"
            },
            {
                "山海双屿-第三关",
                "Shanhai Shuangyu-Third Pass"
            },
            {
                "第三幕首领-测试",
                "Act Three Boss-Test"
            },
            {
                "山海双屿-定海湾",
                ""
            },
            {
                "四幕-第一关",
                "Act Four-Level One"
            },
            {
                "龙陵墓穴-第一层",
                "Dragon Tomb-First Floor"
            },
            {
                "龙陵邃室",
                ""
            },
            {
                "龙陵墓穴-第二层",
                "Dragon Tomb-Second Floor"
            },
            {
                "npc隐藏美术测试",
                "npc hidden art test"
            },
            {
                "汀洲小岸",
                ""
            },
            {
                "测试关卡",
                "Test level"
            },
            {
                "美术第二幕测试关卡",
                "Act Two art test level"
            },
            {
                "组队BOSS",
                "Team BOSS"
            }
        };

        public static RStringDictionary DevLevelNames = new StringDictionary()
        {
            {
                "关",
                "Level"
            },
            {
                "一幕",
                "Act One"
            },
            {
                "美术测试场景",
                "Art test scene"
            },
            {
                "美术测试关卡",
                "Art test level"
            },
            {
                "守护",
                "Guardian"
            },
            {
                "时",
                "Time"
            },
            {
                "测试",
                "test"
            },
            {
                "防守战",
                "Defensive Battle"
            },
            {
                "关护送",
                "Escort"
            },
            {
                "手游",
                "Mobile game"
            },
            {
                "试玩",
                "Demo"
            },
            {
                "特效测试路线",
                "Special effects test route"
            },
            {
                "石巨人",
                "Stone giant"
            },
            {
                "二幕准备室",
                "Act Two Preparation Room"
            },
            {
                "二幕精英关",
                "Act Two Elite Level"
            },
            {
                "二幕",
                "Act Two"
            },
            {
                "二幕生存关",
                "Act Two Survival"
            },
            {
                "二幕美术测试场景",
                "Act Two art test scene"
            },
            {
                "二幕马贼关",
                "Act Two Horsehead Level"
            },
            {
                "二幕流寇关",
                "Act Two Rogue Level"
            },
            {
                "二幕守护",
                "Act Two Guardian"
            },
            {
                "风神",
                "Wind God"
            },
            {
                "三幕—准备室",
                "Act Three-Preparation Room"
            },
            {
                "三幕",
                "Act Three"
            },
            {
                "测试场景",
                "Test Scene"
            },
            {
                "第三幕",
                "Act Three"
            },
            {
                "防守",
                "Defensive"
            },
            {
                "首领",
                "Boss"
            },
            {
                "虬蛇",
                "Horned Snake"
            },
            {
                "四幕",
                "Act Four"
            },
            {
                "组队一幕一关",
                ""
            },
            {
                "精英独角金龟关卡",
                "Elite One-horned Beetle Level"
            },
            {
                "精英马头关",
                "Elite Horse Head Pass"
            },
            {
                "精英赵云关",
                ""
            },
            {
                "精英甲虫关",
                "Elite Beetle"
            },
            {
                "组队二关",
                "Team Two"
            },
            {
                "二幕喷火跳跃关",
                "Act Two Spitfire Parkour"
            },
            {
                "二幕跳跃关",
                "Act Two Parkour"
            },
            {
                "二幕滚石关",
                "Act Two Rolling Stones"
            },
            {
                "二幕跳跃关迭代",
                "Act Two Parkour Iteration"
            },
            {
                "三幕战斗关",
                ""
            },
            {
                "三幕跳跃关",
                "Act Three Parkour"
            },
            {
                "迭代",
                "Iteration"
            },
            {
                "守护关",
                "Guardian Pass"
            },
        };
    }
}

using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileSkillInfo
    {
        public static Dictionary<int, skillinfoclass> skillList;

        public static System.Collections.Generic.Dictionary<int, Classes.SkillInfoClass> parsedSkillList =
            new System.Collections.Generic.Dictionary<int, Classes.SkillInfoClass>();

        internal static void Setup()
        {
            skillList = mobileskillinfo.GetData();
            foreach (KeyValuePair<int, skillinfoclass> skill in skillList)
            {
                parsedSkillList.Add(skill.Key, new Classes.SkillInfoClass(skill.Key, skillList));
            }
        }
    }
}
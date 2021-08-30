using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileSkillInfo
    {
        public static Dictionary<string, skillinfoclass> skillList;

        public static System.Collections.Generic.Dictionary<string, Classes.SkillInfoClass> parsedSkillList =
            new System.Collections.Generic.Dictionary<string, Classes.SkillInfoClass>();

        internal static void Setup()
        {
            skillList = mobileskillinfo.GetData();
            foreach (KeyValuePair<string, skillinfoclass> skill in skillList)
            {
                parsedSkillList.Add(skill.Key, new Classes.SkillInfoClass(skill.Key, skillList));
            }
        }
    }
}
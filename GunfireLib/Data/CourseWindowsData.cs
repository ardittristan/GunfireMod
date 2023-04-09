using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class CourseWindowsData
    {
        public static Dictionary<int, coursewindowsdataclass> windowList;

        public static System.Collections.Generic.Dictionary<int, Classes.CourseWindowsDataClass> parsedWindowList =
            new System.Collections.Generic.Dictionary<int, Classes.CourseWindowsDataClass>();

        internal static void Setup()
        {
            windowList = coursewindowsdata.GetData();
            foreach (KeyValuePair<int, coursewindowsdataclass> window in windowList)
            {
                parsedWindowList.Add(window.Key, new Classes.CourseWindowsDataClass(window.Key, windowList));
            }
        }
    }
}

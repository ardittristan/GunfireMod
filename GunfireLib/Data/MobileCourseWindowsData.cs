using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileCourseWindowsData
    {
        public static Dictionary<string, coursewindowsdataclass> windowList;

        public static System.Collections.Generic.Dictionary<string, Classes.CourseWindowsDataClass> parsedWindowList =
            new System.Collections.Generic.Dictionary<string, Classes.CourseWindowsDataClass>();

        internal static void Setup()
        {
            windowList = mobilecoursewindowsdata.GetData();
            foreach (KeyValuePair<string, coursewindowsdataclass> window in windowList)
            {
                parsedWindowList.Add(window.Key, new Classes.CourseWindowsDataClass(window.Key, windowList));
            }
        }
    }
}
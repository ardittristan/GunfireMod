using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataHelper;
using GunfireLib.Data;
using UnhollowerBaseLib;

namespace GunfireLib.Utils
{
    public static class DataHelpers
    {
        public static string GetEnglishName(this levelconfigdataclass baseClass)
        {
            if (string.IsNullOrWhiteSpace(baseClass.Name)) return "";
            try
            {
                return MapData.MapNames[baseClass.Name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return baseClass.Name;
            }
        }

        public static string GetEnglishDevName(this levelconfigdataclass baseClass)
        {
            if (string.IsNullOrWhiteSpace(baseClass.DevName)) return "";
            try
            {
                return MapData.DevMapNames[baseClass.DevName];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                string DevName = baseClass.DevName;

                DevName = DevName.Replace("（", "(");
                DevName = DevName.Replace("）", ")");
                List<string> matches = Regex.Matches(DevName, "[^\x00-\x7F]+")
                                                .OfType<Match>()
                                                .Select(m => m.Groups[0].Value)
                                                .ToList();

                foreach (string match in matches)
                {
                    try
                    {
                        DevName = DevName.Replace(match, MapData.DevMapNames[match]);
                    }
                    catch (Exception exc) when (exc is Il2CppException || exc is KeyNotFoundException) { };
                }
                return DevName;
            }
        }
    }
}

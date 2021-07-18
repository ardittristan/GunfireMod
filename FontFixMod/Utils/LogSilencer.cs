using System;
using HarmonyLib;
using UnhollowerBaseLib;
using UnityEngine;
using Il2CppObject = Il2CppSystem.Object;
using UnityObject = UnityEngine.Object;

namespace FontFixMod.Utils
{
    /// <summary>
    /// Removes spammy error from creating text on screen
    /// </summary>
    [HarmonyPatch]
    class LogSilencer
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Logger), "Log", new Type[] { typeof(LogType), typeof(Il2CppObject) })]
        public static bool Log(Il2CppObject __1)
        {
            try
            {
                if (__1.GetIl2CppType().ToString() == "System.String")
                {
                    switch (__1.ToString())
                    {
                        case "Trying to add Input (UnityEngine.UI.InputField) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                        case "Trying to add interact_tips (UnityEngine.UI.Image) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                        case "Trying to add SCK_tips (UnityEngine.UI.Image) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                            return false;
                    }
                }
            }
            catch (ObjectCollectedException)
            {
            }
            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Logger), "Log", new Type[] { typeof(LogType), typeof(Il2CppObject), typeof(UnityObject) })]
        public static bool ContextLog(Il2CppObject __1)
        {
            try
            {
                if (__1.GetIl2CppType().ToString() == "System.String")
                {
                    switch (__1.ToString())
                    {
                        case string s when s.StartsWith("Material 1309_jian_") && s.EndsWith(" doesn't have _Stencil property"):
                            return false;
                    }
                }
            }
            catch (ObjectCollectedException)
            {
            }
            return true;
        }
    }
}

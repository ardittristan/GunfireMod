using HarmonyLib;
using System.Reflection;

namespace GunfireLib.Patches
{
    [HarmonyPatch]
    public static class MainManagerPatch
    {
        static bool Prepare(MethodBase original)
        {
            if (original?.Name?.Contains("HaveGMLimit") == true && !GunfireLib.EnableDevMode) return false;

            return true;
        }

        [HarmonyPatch(typeof(MainManager), "HaveGMLimit")]
        [HarmonyPrefix]
        static bool HaveGMLimit(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}

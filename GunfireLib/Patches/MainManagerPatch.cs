using HarmonyLib;
using Il2CppSystem.Reflection;

namespace GunfireLib.Patches
{
    [HarmonyPatch]
    public static class MainManagerPatch
    {
        static bool Prepare(MethodBase original)
        {
            if (original?.FullName?.Contains("HaveGMLimit") == true && !GunfireLib.EnableDevMode) return false;

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

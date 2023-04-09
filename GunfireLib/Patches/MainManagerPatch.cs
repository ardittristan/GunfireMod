// ReSharper disable InconsistentNaming
// ReSharper disable RedundantAssignment
using HarmonyLib;
using System.Reflection;
using Il2Cpp;

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

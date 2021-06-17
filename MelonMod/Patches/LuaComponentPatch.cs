using System;
using HarmonyLib;
using UnityEngine;
using MelonLoader;
using System.Runtime.CompilerServices;

namespace GunfireBaseMod.Patches
{
    //[HarmonyPatch(typeof(LuaComponent))]
    //class LuaComponentPatch : MonoBehaviour
    //{
    //    internal static GameObject Create(string name)
    //    {
    //        var obj = new GameObject(name);
    //        DontDestroyOnLoad(obj);
    //        var component = new LuaComponentPatch(obj.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<LuaComponentPatch>()).Pointer);
    //        return obj;
    //    }

    //    public LuaComponentPatch(IntPtr intPtr) : base(intPtr) { }

    //    public void Awake()
    //    {

    //    }

    //    //[MethodImpl(MethodImplOptions.NoInlining)]
    //    //[HarmonyPostfix]
    //    //[HarmonyPatch("LoadParamToLuaByRuntime")]
    //    //public static void LoadParamToLuaByRuntime(Component __0)
    //    //{
    //    //    MelonLogger.Msg("LuaComponent Fired!");
    //    //}

    //    //[MethodImpl(MethodImplOptions.NoInlining)]
    //    //[HarmonyFinalizer]
    //    //[HarmonyPatch("LoadParamToLuaByRuntime")]
    //    //public static void LoadParamToLuaByRuntimeFinalizer(ref Exception __exception)
    //    //{
    //    //    __exception = null;
    //    //}
    //}
}

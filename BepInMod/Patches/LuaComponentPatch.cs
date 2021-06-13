using System;
using HarmonyLib;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace BepInMod.Patches
{
    class LuaComponentPatch : MonoBehaviour
    {
        internal static GameObject Create(string name)
        {
            var obj = new GameObject(name);
            DontDestroyOnLoad(obj);
            var component = new LuaComponentPatch(obj.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<LuaComponentPatch>()).Pointer);
            return obj;
        }

        public LuaComponentPatch(IntPtr intPtr) : base(intPtr) { }

        public void Awake()
        {

        }

        [HideFromIl2Cpp]
        [HarmonyPostfix]
        public static void LoadParamToLuaByRuntime(Component com)
        {
            BepInExLoader.log.LogMessage("LuaComponent Fired!");
        }
    }
}

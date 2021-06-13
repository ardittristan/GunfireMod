using System;
using HarmonyLib;
using UnityEngine;

namespace BepInMod
{
    class Bootstrapper : MonoBehaviour
    {
        internal static GameObject Create(string name)
        {
            var obj = new GameObject(name);
            DontDestroyOnLoad(obj);
            var component = new Bootstrapper(obj.AddComponent(UnhollowerRuntimeLib.Il2CppType.Of<Bootstrapper>()).Pointer);
            return obj;
        }

        public Bootstrapper(IntPtr intPtr) : base(intPtr) { }

        public void Awake()
        {

        }

        [HarmonyPostfix]
        public static void Update()
        {
            //BepInExLoader.log.LogMessage("Bootstrapper Update() Fired!");
        }
    }
}

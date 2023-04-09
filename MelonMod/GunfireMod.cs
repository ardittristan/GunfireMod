using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2CppGameCoder.Engine;

namespace GunfireBaseMod
{
    public class GunfireMod : MelonMod
    {
        internal new static MelonLogger.Instance LoggerInstance;

        public GunfireMod()
        {
            _ = SetupLogger();
        }

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
            //GunfireMod.LoggerInstance.Msg("OnApplicationQuit");
        }
        public override void OnInitializeMelon() // Runs after Game Initialization.
        {
            //ClassInjector.RegisterTypeInIl2Cpp<Patches.LuaComponentPatch>();
            //ClassInjector.RegisterTypeInIl2Cpp<NPCGate>();

            //HarmonyInstance.PatchAll(typeof(Patches.LuaComponentPatch));
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            //GunfireMod.LoggerInstance.Msg("OnFixedUpdate");
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            //GunfireMod.LoggerInstance.Msg("OnGui");
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            //GunfireMod.LoggerInstance.Msg("OnLateUpdate");
        }

        public override void OnPreferencesLoaded() // Called when a mod calls MelonLoader.MelonPreferences.Load(), or when MelonPreferences loads external changes.
        {
            //GunfireMod.LoggerInstance.Msg("OnPreferencesLoaded");
        }

        public override void OnPreferencesSaved() // Called when a mod calls MelonLoader.MelonPreferences.Save(), or when the application quits.
        {
            //GunfireMod.LoggerInstance.Msg("OnPreferencesSaved");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) // Runs when a Scene has Initialized.
        {
            LoggerInstance.Msg("OnSceneWasInitialized - sceneName: " + sceneName);
            LoggerInstance.Msg("OnSceneWasInitialized - parsedSceneName: " + DYSceneManager.GetABName(sceneName));
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName) // Runs when a Scene has Loaded.
        {
            LoggerInstance.Msg("OnSceneWasLoaded - buildIndex: " + buildIndex.ToString());
            LoggerInstance.Msg("OnSceneWasLoaded - sceneName: " + sceneName);
            LoggerInstance.Msg("OnSceneWasLoaded - parsedSceneName: " + DYSceneManager.GetABName(sceneName));
        }

        public override void OnUpdate() // Runs once per frame.
        {
            
        }

        private async Task SetupLogger()
        {
            await Task.Run(() =>
            {
                while (base.LoggerInstance == null)
                {
                    Task.Delay(1).Wait();
                }

                LoggerInstance = base.LoggerInstance;
            });
        }
    }

    [HarmonyPatch]
    public class Patch
    {
        [HarmonyPatch(typeof(NpcTrigger), "ShowHideDoorTip")]
        [HarmonyPostfix]
        public static void ShowHideDoorTip(Collider __0, bool __1)
        {
            GunfireMod.LoggerInstance.Msg(__0);
            GunfireMod.LoggerInstance.Msg(__1);
        }
    }
}

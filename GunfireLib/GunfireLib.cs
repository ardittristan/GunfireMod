using System;
using System.Linq;
using MelonLoader;
using UnityEngine;
using GunfireLib.Instances;
using GunfireLib.Patches;

namespace GunfireLib
{
    public class GunfireLib : MelonMod
    {
        internal static HarmonyLib.Harmony harmony;
        internal static readonly bool verboseLog = Environment.GetCommandLineArgs().Any(s => s.Contains("--gunfirelib.verbose"));

        public GunfireLib()
        {
            harmony = HarmonyInstance;

            HarmonyLib.Tools.Logger.ChannelFilter = HarmonyLib.Tools.Logger.LogChannel.All;
            HarmonyLib.Tools.HarmonyFileLog.Enabled = true;

            Debug.developerConsoleVisible = true;
        }

        public override void OnApplicationLateStart()
        {
            MelonLogger.Msg("OnApplicationLateStart");
        }

        public override void OnApplicationQuit()
        {
            MelonLogger.Msg("OnApplicationQuit");
        }
        public override void OnApplicationStart()
        {
            PortalInstance.Setup();
            ScriptEventManagerPatch.Setup();
        }

        public override void OnFixedUpdate()
        {
            //MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnGUI()
        {
            //MelonLogger.Msg("OnGui");
        }

        public override void OnLateUpdate()
        {
            //MelonLogger.Msg("OnLateUpdate");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnSceneWasInitialized");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnSceneWasLoaded");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Home))
            {
                GameSceneManager.BackToHome();
            }
        }
    }
}

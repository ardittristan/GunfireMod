using MelonLoader;
using UnityEngine;
using GunfireLib.Instances;

namespace GunfireLib
{
    public class GunfireLib : MelonMod
    {
        public GunfireLib()
        {
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

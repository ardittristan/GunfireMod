// ReSharper disable StringLiteralTypo
using System;
using System.IO;
using System.Linq;
using MelonLoader;
using UnityEngine;
using GunfireLib.Instances;
using GunfireLib.Patches;
using GunfireLib.Utils;

namespace GunfireLib
{
    public class GunfireLib : MelonMod
    {
        internal static HarmonyLib.Harmony harmony;

        internal static readonly bool VerboseLog =
            Environment.GetCommandLineArgs().Any(s => s.Contains("--gunfirelib.verbose"));

        internal static readonly bool FileLog =
            Environment.GetCommandLineArgs().Any(s => s.Contains("--gunfirelib.filelog"));

        internal static readonly string LibConfigDirectory =
            Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ??
                throw new InvalidOperationException(), "GunfireLib");

        private static bool _firstHomeLoad = true;
        private static bool _firstLateHomeLoad = true;

        public GunfireLib()
        {
            harmony = HarmonyInstance;

            HarmonyLib.Tools.Logger.ChannelFilter = HarmonyLib.Tools.Logger.LogChannel.All;
            HarmonyLib.Tools.HarmonyFileLog.Enabled = true;

            Debug.developerConsoleVisible = true;

            if (FileLog)
            {
                Directory.CreateDirectory(LibConfigDirectory);
            }
        }

        public override void OnApplicationLateStart()
        {

        }

        public override void OnApplicationQuit()
        {
            GunfireEvents.RaiseQuitEvent();
        }

        public override void OnApplicationStart()
        {
            if (FileLog) SetupStore.Setup();
            PortalInstance.Setup();
            ScriptEventManagerPatch.Setup();
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnGUI()
        {

        }

        public override void OnLateUpdate()
        {

        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (_firstLateHomeLoad && sceneName == "home")
            {
                _firstLateHomeLoad = false;
                GunfireEvents.RaiseLateGameLoaded();
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (_firstHomeLoad && sceneName == "home")
            {
                if (FileLog) SetupStore.LateSetup();
                SetupData.Setup();

                _firstHomeLoad = false;
                GunfireEvents.RaiseGameLoaded();
            }
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

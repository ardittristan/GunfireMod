﻿using System;
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
        internal static readonly bool verboseLog = Environment.GetCommandLineArgs().Any(s => s.Contains("--gunfirelib.verbose"));
        internal static readonly bool fileLog = Environment.GetCommandLineArgs().Any(s => s.Contains("--gunfirelib.filelog"));
        internal static readonly string libConfigDirectory = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "GunfireLib");

        public GunfireLib()
        {
            harmony = HarmonyInstance;

            HarmonyLib.Tools.Logger.ChannelFilter = HarmonyLib.Tools.Logger.LogChannel.All;
            HarmonyLib.Tools.HarmonyFileLog.Enabled = true;

            Debug.developerConsoleVisible = true;

            if (fileLog)
            { 
                Directory.CreateDirectory(libConfigDirectory);
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

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

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

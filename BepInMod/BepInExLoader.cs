

using System;
using BepInEx;
using HarmonyLib;
using HarmonyLib.Tools;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace BepInMod
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BepInEx.IL2CPP.BasePlugin
    {
        #region[Declarations]

        public const string
            MODNAME = "GunfireMod",
            AUTHOR = "ardittristan",
            GUID = "xyz." + AUTHOR + "." + MODNAME,
            VERSION = "1.0.0.0";

        public static BepInEx.Logging.ManualLogSource log;

        #endregion

        public BepInExLoader()
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
            Application.runInBackground = true;
            log = Log;
        }

        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e) => log.LogError("\r\n\r\nUnhandled Exception:" + (e.ExceptionObject as Exception).ToString());

        public override void Load()
        {
            #region[Register Component in Il2Cpp]

            try
            {
                log.LogMessage("Registering C# Type's in Il2Cpp");

                //ClassInjector.RegisterTypeInIl2Cpp<Bootstrapper>();
            }
            catch
            {
                log.LogError("FAILED to Register Il2Cpp Type!");
            }

            #endregion

            #region[Harmony Patching]

            try
            {
                log.LogMessage(" ");
                log.LogMessage("Inserting Harmony Hooks...");

                var harmony = new Harmony("ardittristan.gunfiremod.il2cpp");

                #region[Enable/Disable Harmony Debug Log]

                HarmonyFileLog.Enabled = true;

                #endregion

                #region[Patch() Hook]

                //harmony code

                #endregion

                log.LogMessage("Runtime Hooks Applied");
                log.LogMessage(" ");
            }
            catch
            {
                log.LogError("FAILED to Apply Hooks!");
            }

            #endregion

            log.LogMessage("Initializng Il2CppTypeSupport...");
            Il2CppTypeSupport.Initialize();


        }
    }
}

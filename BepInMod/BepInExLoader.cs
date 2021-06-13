

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

                ClassInjector.RegisterTypeInIl2Cpp<Bootstrapper>();
                ClassInjector.RegisterTypeInIl2Cpp<Patches.LuaComponentPatch>();
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

                #region[Update() Hook - Only Needed for Bootstrapper]

                var originalUpdate = AccessTools.Method(typeof(UnityEngine.UI.CanvasScaler), "Update");
                log.LogMessage("   Original Method: " + originalUpdate.DeclaringType.Name + "." + originalUpdate.Name);
                var postUpdate = AccessTools.Method(typeof(Bootstrapper), "Update");
                log.LogMessage("   Postfix Method: " + postUpdate.DeclaringType.Name + "." + postUpdate.Name);
                harmony.Patch(originalUpdate, postfix: new HarmonyMethod(postUpdate));

                #endregion

                #region[LuaComponent Patch]

                var originalLoadParamToLuaByRuntime = AccessTools.Method(typeof(LuaComponent), "LoadParamToLuaByRuntime");
                log.LogMessage("   Original Method: " + originalLoadParamToLuaByRuntime.DeclaringType.Name + "." + originalLoadParamToLuaByRuntime.Name);
                var postLoadParamToLuaByRuntime = AccessTools.Method(typeof(Patches.LuaComponentPatch), "LoadParamToLuaByRuntime");
                log.LogMessage("   Postfix Method: " + postLoadParamToLuaByRuntime.DeclaringType.Name + "." + postLoadParamToLuaByRuntime.Name);
                harmony.Patch(originalLoadParamToLuaByRuntime, postfix: new HarmonyMethod(postLoadParamToLuaByRuntime));

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

            Bootstrapper.Create("BootStrapperGO");
            Patches.LuaComponentPatch.Create("LuaComponentPatchGO");
        }
    }
}

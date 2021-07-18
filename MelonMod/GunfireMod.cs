using UnityEngine;
using MelonLoader;
<<<<<<< HEAD
<<<<<<< HEAD
using Il2CppSystem;
using UnhollowerBaseLib;
using Guide;
using HarmonyLib;
using DYPublic.Duonet;
using Game;
<<<<<<< HEAD
=======
using Il2CppSystem.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Collections.Generic;
<<<<<<< HEAD:GunfireMod.cs
>>>>>>> e26310b... Try more things
=======
using UnhollowerRuntimeLib;
<<<<<<< HEAD
>>>>>>> fd037b3... split into 2 different loaders:MelonMod/GunfireMod.cs
=======
using HarmonyLib.Tools;
using Logger = HarmonyLib.Tools.Logger;
>>>>>>> 71a63e2... let the console spam commence
=======
>>>>>>> bbde83e... add initial fontfix mod
=======
using HarmonyLib;
using GameCoder.Engine;
>>>>>>> 2e3c525... switch logic over to lib mod

namespace GunfireBaseMod
{
    public class GunfireMod : MelonMod
    {
        public GunfireMod()
        {
        }

        public override void OnApplicationLateStart() // Runs after Application Start has finished.
        {
            //MelonLogger.Msg("OnApplicationLateStart");
        }

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
            //MelonLogger.Msg("OnApplicationQuit");
        }
        public override void OnApplicationStart() // Runs after Game Initialization.
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
            

            DYPublic.XLog.Logger.Log(DYPublic.XLog.LogLevel.LevelWarn, "Test");
>>>>>>> e26310b... Try more things
=======
=======

>>>>>>> bbde83e... add initial fontfix mod
            //ClassInjector.RegisterTypeInIl2Cpp<Patches.LuaComponentPatch>();
            //ClassInjector.RegisterTypeInIl2Cpp<NPCGate>();

            //HarmonyInstance.PatchAll(typeof(Patches.LuaComponentPatch));
<<<<<<< HEAD

<<<<<<< HEAD

>>>>>>> 71a63e2... let the console spam commence
            MelonLogger.Msg("OnApplicationStart");
=======
            Modifications.PortalBehaviour.Setup();
>>>>>>> bbde83e... add initial fontfix mod
=======
>>>>>>> 2e3c525... switch logic over to lib mod
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            //MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            //MelonLogger.Msg("OnGui");
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            //MelonLogger.Msg("OnLateUpdate");
        }

        public override void OnPreferencesLoaded() // Called when a mod calls MelonLoader.MelonPreferences.Load(), or when MelonPreferences loads external changes.
        {
            //MelonLogger.Msg("OnPreferencesLoaded");
        }

        public override void OnPreferencesSaved() // Called when a mod calls MelonLoader.MelonPreferences.Save(), or when the application quits.
        {
            //MelonLogger.Msg("OnPreferencesSaved");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) // Runs when a Scene has Initialized.
        {
            MelonLogger.Msg("OnSceneWasInitialized - buildIndex: " + buildIndex.ToString());
            MelonLogger.Msg("OnSceneWasInitialized - sceneName: " + sceneName);
            MelonLogger.Msg("OnSceneWasInitialized - parsedSceneName: " + DYSceneManager.GetABName(sceneName));
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName) // Runs when a Scene has Loaded.
        {
            MelonLogger.Msg("OnSceneWasLoaded - buildIndex: " + buildIndex.ToString());
            MelonLogger.Msg("OnSceneWasLoaded - sceneName: " + sceneName);
            MelonLogger.Msg("OnSceneWasLoaded - parsedSceneName: " + DYSceneManager.GetABName(sceneName));
        }

        public override void OnUpdate() // Runs once per frame.
        {
            
        }

    }

    [HarmonyPatch]
    public class Patch
    {
        [HarmonyPatch(typeof(NpcTrigger), "ShowHideDoorTip")]
        [HarmonyPostfix]
        public static void ShowHideDoorTip(Collider __0, bool __1)
        {
            MelonLogger.Msg(__0);
            MelonLogger.Msg(__1);
        }
    }

    //[HarmonyPatch]
    //public class Patch
    //{
    //    [HarmonyPatch(typeof(AkGameObj), "OnCustomTrigger")]
    //    [HarmonyPostfix]
    //    public static void onCustomTrigger(string __0)
    //    {
    //        MelonLogger.Msg(__0);
    //    }

    //    //[HarmonyPatch(typeof(AkTriggerMouseEnter), "OnMouseEnter")]
    //    //[HarmonyPostfix]
    //    //public static void onMouseEnter()
    //    //{
    //    //    MelonLogger.Msg("mouseenter");
    //    //}
    //}

    // on player object change
    //[HarmonyPatch(typeof(OC1stPlayer), "OnHeroChange")]
    //public class Hero_Change_Event_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref Il2CppReferenceArray<Il2CppSystem.Object> msg, OC1stPlayer __instance)
    //    {
    //        MelonLogger.Msg("OnHeroChange");
    //        MelonLogger.Msg(msg);
    //        MelonLogger.Msg(__instance);
    //    }
    //}

    //[HarmonyPatch(typeof(AkEvent), "HandleEvent")]
    //public class AkEvent_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref GameObject in_gameObject, ref AkEvent __instance)
    //    {
    //        MelonLogger.Msg("HandleAkEvent");
    //        if (!Il2CppSystem.Object.ReferenceEquals(in_gameObject, null))
    //        {
    //            MelonLogger.Msg(in_gameObject.name);
    //        }
    //        MelonLogger.Msg(__instance.eventID);
    //    }
    //}

    //[HarmonyPatch()]
    //public class Custom_Patch
    //{
    //    IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    //    {
    //        return new CodeMatcher(instructions).MatchForward(false,
    //            new CodeMatch(OpCodes.Stfld),
    //            new CodeMatch(OpCodes.Ldarg_0),
    //            new CodeMatch(i => i.opcode == OpCodes.Ldfld && ((FieldInfo)i.operand).Name == "test"));
    //    }
    //}

    //[HarmonyPatch(typeof(AkTriggerCustom), "OnAkTrigger")]
    //public class AkTriggerCustom_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(AkTriggerCustom __instance)
    //    {
    //        MelonLogger.Msg("HandleAkTriggerCustom");
    //        MelonLogger.Msg(__instance.TriggerEventName);
    //    }
    //}

    //[HarmonyPatch(typeof(LuaComBase), nameof(LuaComBase.AniEventChange))]
    //public class LuaComponent_Patch
    //{
    //    public static void Prefix(ref Il2CppReferenceArray<Il2CppSystem.Object> __0)
    //    {
    //        if (__0 != null)
    //        {
    //            MelonLogger.Msg(__0.Length);
    //        }
    //    }
    //}

    //[HarmonyPatch(typeof(OCDrop.OCDropBase), "SetDropItem")]
    //public class OpOverDropItem_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref ItemObject item)
    //    {
    //        MelonLogger.Msg("SetDropItem");
    //        MelonLogger.Msg(item.ItemID);
    //    }
    //}

    //[HarmonyPatch(typeof(TriggerManager), "OnEnterTrigger")]
    //public class Trigger_Event_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref String enterName, ref Boolean isDrop, TriggerManager __instance)
    //    {
    //        MelonLogger.Msg(__instance.ToString());
    //        MelonLogger.Msg("OnEnterTrigger");
    //        MelonLogger.Msg(enterName);
    //        MelonLogger.Msg(isDrop);

    //    }
    //}

    //[HarmonyPatch(typeof(SpeNearGateGuide), "CheckProtalButton")]
    //public class Near_Gate_Guide_Event_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(Il2CppReferenceArray<Il2CppSystem.Object> msg)
    //    {
    //        MelonLogger.Msg("CheckProtalButton");
    //        MelonLogger.Msg(msg);
    //    }
    //}

    //[HarmonyPatch(typeof(SpeNearGateGuide), "CheckProtalButton2")]
    //public class Near_Gate_Guide_2_Event_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(Il2CppReferenceArray<Il2CppSystem.Object> msg)
    //    {
    //        MelonLogger.Msg("CheckProtalButton2");
    //        MelonLogger.Msg(msg);
    //    }
    //}

    //[HarmonyPatch(typeof(S2CDuoNet), "s2cwarop_GS2CMapTriggerGate")]
    //public class Duo_Net_CG2_CMap_Trigger_Gate_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(NetFunc.basenet netobj)
    //    {
    //        MelonLogger.Msg(netobj);
    //        MelonLogger.Msg("s2cwarop_GS2CMapTriggerGate");
    //    }
    //}

    //[HarmonyPatch(typeof(SeverLoadSceneManager), "startLoad")]
    //public class Start_Load_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(OneSeverLoadSceneData info)
    //    {
    //        MelonLogger.Msg(info);
    //        MelonLogger.Msg("startLoad");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(String type)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg("ExecEvent");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_1_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1>(String type, T1 arg0)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg("ExecEvent1");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_2_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2>(String type, T1 arg0, T2 arg1)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg("ExecEvent2");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_3_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3>(String type, T1 arg0, T2 arg1, T3 arg2)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg("ExecEvent3");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_4_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg("ExecEvent4");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_5_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg("ExecEvent5");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_6_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg("ExecEvent6");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_7_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg("ExecEvent7");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_8_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7, T8>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg(arg7);
    //        MelonLogger.Msg("ExecEvent8");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_9_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7, T8, T9>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg(arg7);
    //        MelonLogger.Msg(arg8);
    //        MelonLogger.Msg("ExecEvent9");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_10_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg(arg7);
    //        MelonLogger.Msg(arg8);
    //        MelonLogger.Msg(arg9);
    //        MelonLogger.Msg("ExecEvent10");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_11_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg(arg7);
    //        MelonLogger.Msg(arg8);
    //        MelonLogger.Msg(arg9);
    //        MelonLogger.Msg(arg10);
    //        MelonLogger.Msg("ExecEvent11");
    //    }
    //}

    //[HarmonyPatch(typeof(ScriptEventManager), "ExecEvent")]
    //public class Exec_Event_12_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(String type, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11)
    //    {
    //        MelonLogger.Msg(type);
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(arg3);
    //        MelonLogger.Msg(arg4);
    //        MelonLogger.Msg(arg5);
    //        MelonLogger.Msg(arg6);
    //        MelonLogger.Msg(arg7);
    //        MelonLogger.Msg(arg8);
    //        MelonLogger.Msg(arg9);
    //        MelonLogger.Msg(arg10);
    //        MelonLogger.Msg(arg11);
    //        MelonLogger.Msg("ExecEvent12");
    //    }
    //}

    //[HarmonyPatch(typeof(s2cwarop), "GS2CMapTriggerGate")]
    //public class CG2_CMap_Trigger_Gate_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref s2cwarop_GS2CMapTriggerGateClass data)
    //    {
    //        MelonLogger.Msg(data);
    //        MelonLogger.Msg("GS2CMapTriggerGate");
    //    }
    //}

    //[HarmonyPatch(typeof(s2cwarop), "GS2CMapTriggerUpStone")]
    //public class CG2_CMap_Trigger_Up_Stone_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(s2cwarop_GS2CMapTriggerUpStoneClass data)
    //    {
    //        MelonLogger.Msg(data);
    //        MelonLogger.Msg("GS2CMapTriggerUpStone");
    //    }
    //}

    //[HarmonyPatch(typeof(s2cwarop), "GS2CMapGoto")]
    //public class CG2_CMap_Goto_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref s2cwarop_GS2CMapGotoClass data)
    //    {
    //        MelonLogger.Msg(data);
    //        MelonLogger.Msg("GS2CMapGoto");
    //    }
    //}

    //[HarmonyPatch(typeof(ManagerBase), "WarUpdate")]
    //public class War_Update_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix()
    //    {
    //        MelonLogger.Msg("WarUpdate");
    //    }
    //}

    //[HarmonyPatch(typeof(ManagerBase), "GlobalUpdate")]
    //public class Global_Update_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix()
    //    {
    //        MelonLogger.Msg("GlobalUpdate");
    //    }
    //}

    //[HarmonyPatch(typeof(MainManager), "OnCurfewConfirm")]
    //public class On_Curfew_Confirm_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix()
    //    {
    //        MelonLogger.Msg("OnCurfewConfirm");
    //    }
    //}

    //[HarmonyPatch(typeof(MainManager), "SwithScene")]
    //public class Switch_Scene_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix()
    //    {
    //        MelonLogger.Msg("SwithScene");
    //    }
    //}

    //[HarmonyPatch(typeof(GameSceneManager), "WarEndToBackHome")]
    //public class War_End_To_Back_Home_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix()
    //    {
    //        MelonLogger.Msg("WarEndToBackHome");
    //    }
    //}

    //[HarmonyPatch(typeof(GameSceneManager), "LoadSceneAsync")]
    //public class Load_Scene_Async_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(String sceneName)
    //    {
    //        MelonLogger.Msg(sceneName);
    //        MelonLogger.Msg("LoadSceneAsync");
    //    }
    //}

    //[HarmonyPatch(typeof(Buttonevent), "BeginInvoke")]
    //public class Button_Begin_Invoke_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(AsyncCallback callback, Il2CppSystem.Object @object)
    //    {
    //        MelonLogger.Msg(callback);
    //        MelonLogger.Msg(@object);
    //        MelonLogger.Msg("ButtonBeginInvoke");
    //    }
    //}

    //[HarmonyPatch(typeof(Buttonevent), "EndInvoke")]
    //public class Button_End_Invoke_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(IAsyncResult result)
    //    {
    //        MelonLogger.Msg(result);
    //        MelonLogger.Msg("ButtonEndInvoke");
    //    }
    //}

    //[HarmonyPatch(typeof(Game.EventHandler), "BeginInvoke")]
    //public class Begin_Invoke_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref AsyncCallback callback, ref Il2CppSystem.Object @object)
    //    {
    //        MelonLogger.Msg(callback);
    //        MelonLogger.Msg(@object);
    //        MelonLogger.Msg("BeginInvoke");
    //    }
    //}

    //[HarmonyPatch(typeof(Game.EventHandler), "EndInvoke")]
    //public class End_Invoke_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref IAsyncResult result)
    //    {
    //        MelonLogger.Msg(result);
    //        MelonLogger.Msg("EndInvoke");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith1Arg), "BeginInvoke")]
    //public class Begin_Invoke_1_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref Il2CppSystem.Object arg0, ref AsyncCallback callback, ref Il2CppSystem.Object @object)
    //    {
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(callback);
    //        MelonLogger.Msg(@object);
    //        MelonLogger.Msg("BeginInvoke1");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith1Arg), "EndInvoke")]
    //public class End_Invoke_1_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref IAsyncResult result)
    //    {
    //        MelonLogger.Msg(result);
    //        MelonLogger.Msg("EndInvoke1");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith2Arg), "BeginInvoke")]
    //public class Begin_Invoke_2_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref Il2CppSystem.Object arg0, ref Il2CppSystem.Object arg1, ref AsyncCallback callback, ref Il2CppSystem.Object @object)
    //    {
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(callback);
    //        MelonLogger.Msg(@object);
    //        MelonLogger.Msg("BeginInvoke2");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith2Arg), "EndInvoke")]
    //public class End_Invoke_2_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref IAsyncResult result)
    //    {
    //        MelonLogger.Msg(result);
    //        MelonLogger.Msg("EndInvoke2");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith3Arg), "BeginInvoke")]
    //public class Begin_Invoke_3_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref Il2CppSystem.Object arg0, ref Il2CppSystem.Object arg1, ref Il2CppSystem.Object arg2, ref AsyncCallback callback, ref Il2CppSystem.Object @object)
    //    {
    //        MelonLogger.Msg(arg0);
    //        MelonLogger.Msg(arg1);
    //        MelonLogger.Msg(arg2);
    //        MelonLogger.Msg(callback);
    //        MelonLogger.Msg(@object);
    //        MelonLogger.Msg("BeginInvoke3");
    //    }
    //}

    //[HarmonyPatch(typeof(EventHandlerWith3Arg), "EndInvoke")]
    //public class End_Invoke_3_Action_Patch
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(ref IAsyncResult result)
    //    {
    //        MelonLogger.Msg(result);
    //        MelonLogger.Msg("EndInvoke3");
    //    }
    //}
}

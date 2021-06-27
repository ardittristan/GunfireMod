using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using FontFixMod.Util;
using HarmonyLib;
using MelonLoader;
using TMPro;
using UnhollowerRuntimeLib;
using UnityEngine;
using WindowsInput;
using WindowsInput.Events.Sources;
using WinKeyCode = WindowsInput.Events.KeyCode;

namespace FontFixMod
{
    /// <summary>
    /// Defines the <see cref="FontFix" />.
    /// </summary>
    public class FontFix : MelonMod
    {
        public FontFix()
        {
            if (!importedDependencies)
            {
                MelonLogger.Msg("test");
                AssemblyResolver.Hook(Path.Combine(MelonUtils.GameDirectory, "Mods", "FontFixMod"));
                importedDependencies = true;
            }
        }

        public static bool importedDependencies = false;

        /// <summary>
        /// OnApplicationStart.
        /// </summary>
        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<IKeyboardEventSource>();
            ClassInjector.RegisterTypeInIl2Cpp<EventSourceEventArgs>();
            ClassInjector.RegisterTypeInIl2Cpp<KeyboardEvent>();
            ClassInjector.RegisterTypeInIl2Cpp<CustomKeyboardLogic>();

            CustomKeyboardLogic.Setup();

            using IKeyboardEventSource Keyboard = Capture.Global.KeyboardAsync();
            Keyboard.KeyEvent += Keyboard_KeyEvent;
        }

        private static void Keyboard_KeyEvent(object sender, EventSourceEventArgs<KeyboardEvent> e)
        {
            WinKeyCode key = (WinKeyCode)(e.Data?.KeyDown?.Key);
            switch (key)
            {
                case WinKeyCode.F19:
                    CustomKeyboardLogic.Instance.keyCode = key;
                    Simulate.Events().Click(WinKeyCode.Help);
                    break;
            }
        }
    }

    /// <summary>
    /// Patches for <see cref="TMP_Text" />.
    /// </summary>
    [HarmonyPatch]
    class TMP_Text_Patch
    {
        /// <summary>
        /// Hooks before text gets rendered.
        /// </summary>
        /// <param name="__instance">The current <see cref="TextMeshProUGUI"/> instance.</param>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(TextMeshProUGUI), "OnPreRenderCanvas")]
        public static void OnPreRenderCanvas(TextMeshProUGUI __instance)
        {
            if (__instance != null)
            {
                string text = __instance.text;
                MelonLogger.Msg(text);
                if (text.Contains("sprite") && text.Contains("name=sck"))
                {
                    switch (GetEnumValueFromDescription(text))
                    {
                        case Characters.F13:
                            #region[Set F13 Text]
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F13),
                                    String.Format(
                                        "<sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha3
                                    )
                                )
                            );
                            #endregion
                            break;
                        case Characters.F14:
                            #region[Set F14 Text]
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F14),
                                    String.Format(
                                        "<sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha4
                                    )
                                )
                            );
                            #endregion
                            break;
                        case Characters.F15:
                            #region[Set F15 Text]
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F15),
                                    String.Format(
                                        "<sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha5
                                    )
                                )
                            );
                            #endregion
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Enum with missing sprites and their respected key
        /// </summary>
        public enum Characters
        {
            [Description("<sprite name=sck294>")]
            F13,
            [Description("<sprite name=sck295>")]
            F14,
            [Description("<sprite name=sck296>")]
            F15
        }

        /// <summary>
        /// Get Enum value from a description.
        /// </summary>
        /// <param name="description">Enum description <see cref="string"/>.</param>
        /// <returns><see cref="Characters">Character</see>.</returns>
        public static Characters GetEnumValueFromDescription(string description)
        {
            var type = typeof(Characters);
            FieldInfo[] fields = type.GetFields();
            var field = fields
                .SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (
                       f, a) => new { Field = f, Att = a })
                .Where(a => description.Contains(((DescriptionAttribute)a.Att).Description)).SingleOrDefault();
            return field == null ? default : (Characters)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Get Enum description from value.
        /// </summary>
        /// <param name="value">The <see cref="Characters"/> Enum value.</param>
        /// <returns>Description <see cref="string"/>.</returns>
        public static string GetDescriptionFromEnumValue(Characters value)
        {
            return value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() is not DescriptionAttribute attribute ? value.ToString() : attribute.Description;
        }
    }

    /// <summary>
    /// Defines the <see cref="Input_Patch" />.
    /// </summary>
    [HarmonyPatch]
    class Input_Patch
    {
        public Input_Patch()
        {
            if (!FontFix.importedDependencies)
            {
                MelonLogger.Msg("test");
                AssemblyResolver.Hook(Path.Combine(MelonUtils.GameDirectory, "Mods", "FontFixMod"));
                FontFix.importedDependencies = true;
            }
        }

        /// <summary>
        /// The GetKey.
        /// </summary>
        /// <param name="__0">The __0<see cref="KeyCode"/>.</param>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Input), "GetKey", new Type[] { typeof(KeyCode) })]
        public static void GetKey(ref KeyCode __0)
        {
            if (__0 == KeyCode.Help)
            {
                MelonLogger.Msg(__0);
                MelonLogger.Msg(CustomKeyboardLogic.Instance.keyCode);
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Input), "GetKey", new Type[] { typeof(string) })]
        public static void GetKeyByString(ref string __0)
        {
            if (__0 == KeyCode.Help.ToString())
            {
                MelonLogger.Msg(__0);
                MelonLogger.Msg(CustomKeyboardLogic.Instance.keyCode);
            }
        }
    }

    /// <summary>
    /// Defines the <see cref="CustomKeyboardLogic" />.
    /// </summary>
    class CustomKeyboardLogic : MonoBehaviour
    {
        /// <summary>
        /// Gets the Instance.
        /// </summary>
        internal static CustomKeyboardLogic Instance { get; private set; }

        /// <summary>
        /// The Setup.
        /// </summary>
        internal static void Setup()
        {
            var obj = new GameObject("CustomKeyboardLogic");
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;
            obj.tag = "CustomKeyboardLogic";
            Instance = obj.AddComponent<CustomKeyboardLogic>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyboardLogic"/> class.
        /// </summary>
        /// <param name="ptr">The ptr<see cref="IntPtr"/>.</param>
        public CustomKeyboardLogic(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Defines the keyCode.
        /// </summary>
        public WinKeyCode? keyCode = null;
    }
}

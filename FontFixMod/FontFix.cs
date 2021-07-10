﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using TMPro;
using UnhollowerBaseLib;
using Il2CppObject = Il2CppSystem.Object;
using UnityEngine;
using UnityEngine.UI;

namespace FontFixMod
{
    /// <summary>
    /// Defines the <see cref="FontFix" />.
    /// </summary>
    public class FontFix : MelonMod
    {
        FontFix() { }
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
                if (text.Contains("sprite") && text.Contains("name=sck"))
                {
                    int length = 0;
                    switch (GetEnumValueFromDescription(text))
                    {
                        case Characters.F13:
                            #region[Set F13 Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.F13),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                    (int)KeyCode.F,
                                    (int)KeyCode.Alpha1,
                                    (int)KeyCode.Alpha3
                                )
                            );
                            length = 3;
                            #endregion
                            break;
                        case Characters.F14:
                            #region[Set F14 Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.F14),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                    (int)KeyCode.F,
                                    (int)KeyCode.Alpha1,
                                    (int)KeyCode.Alpha4
                                )
                            );
                            length = 3;
                            #endregion
                            break;
                        case Characters.F15:
                            #region[Set F15 Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.F15),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                    (int)KeyCode.F,
                                    (int)KeyCode.Alpha1,
                                    (int)KeyCode.Alpha5
                                )
                            );
                            length = 3;
                            #endregion
                            break;
                        case Characters.NUMDIVIDE:
                            #region[Set NUMDIVIDE Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.NUMDIVIDE),
                                "<sprite name=sck92>"
                            );
                            #endregion
                            break;
                        case Characters.NUMEQUALS:
                            #region[Set NUMEQUALS Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.NUMEQUALS),
                                "<sprite name=sck61>"
                            );
                            #endregion
                            break;
                        case Characters.NUMLOCK:
                            #region[Set NUMLOCK Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.NUMLOCK),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}><sprite name=sck{3}><sprite name=sck{4}><sprite name=sck{5}><sprite name=sck{6}></cspace></size>",
                                    (int)KeyCode.N,
                                    (int)KeyCode.U,
                                    (int)KeyCode.M,
                                    (int)KeyCode.L,
                                    (int)KeyCode.O,
                                    (int)KeyCode.C,
                                    (int)KeyCode.K
                                )
                            );
                            length = 7;
                            #endregion
                            break;
                        case Characters.SCROLLLOCK:
                            #region[Set SCROLLLOCK Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.SCROLLLOCK),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}><sprite name=sck{3}><sprite name=sck{4}><sprite name=sck{5}><sprite name=sck{6}><sprite name=sck{7}><sprite name=sck{8}><sprite name=sck{9}></cspace></size>",
                                    (int)KeyCode.S,
                                    (int)KeyCode.C,
                                    (int)KeyCode.R,
                                    (int)KeyCode.O,
                                    (int)KeyCode.L,
                                    (int)KeyCode.L,
                                    (int)KeyCode.L,
                                    (int)KeyCode.O,
                                    (int)KeyCode.C,
                                    (int)KeyCode.K
                                )
                            );
                            length = 10;
                            #endregion
                            break;
                        case Characters.BREAK:
                            #region[Set BREAK Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.BREAK),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}><sprite name=sck{3}><sprite name=sck{4}></cspace></size>",
                                    (int)KeyCode.B,
                                    (int)KeyCode.R,
                                    (int)KeyCode.E,
                                    (int)KeyCode.A,
                                    (int)KeyCode.K
                                )
                            );
                            length = 5;
                            #endregion
                            break;
                        case Characters.MENU:
                            #region[Set MENU Text]
                            __instance.text = text.Replace(
                                GetDescriptionFromEnumValue(Characters.MENU),
                                String.Format(
                                    "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}><sprite name=sck{3}></cspace></size>",
                                    (int)KeyCode.M,
                                    (int)KeyCode.E,
                                    (int)KeyCode.N,
                                    (int)KeyCode.U
                                )
                            );
                            length = 4;
                            #endregion
                            break;
                    }

                    if (length != 0)
                    {
                        Image textContainer = __instance.GetComponentsInParent<Image>(true)
                            .Where(a => a.sprite != null && a.sprite.name == "img_pick_bg")
                            .SingleOrDefault();
                        if (textContainer != null)
                        {
                            RectTransform transform = textContainer.rectTransform;

                            Vector2 sizeDelta = transform.sizeDelta;

                            Vector2 oldOffsetMax = transform.get_offsetMax();
                            transform.set_offsetMax(new Vector2(oldOffsetMax.x < 240 ? oldOffsetMax.x + (int)((33 * (length - 1) * 0.5)) : oldOffsetMax.x, oldOffsetMax.y));

                            Vector4 oldMargin = __instance.margin;
                            __instance.margin = new Vector4(oldMargin.x < 2 ? oldMargin.x + length * 2 : oldMargin.x, oldMargin.y, oldMargin.z, oldMargin.w);
                        }
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
            F15,
            [Description("<sprite name=sck267>")]
            NUMDIVIDE,
            [Description("<sprite name=sck272>")]
            NUMEQUALS,
            [Description("<sprite name=sck300>")]
            NUMLOCK,
            [Description("<sprite name=sck302>")]
            SCROLLLOCK,
            [Description("<sprite name=sck318>")]
            BREAK,
            [Description("<sprite name=sck318>")]
            MENU
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
    /// Removes spammy error from creating text on screen
    /// </summary>
    [HarmonyPatch]
    class Logger_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Logger), "Log", new Type[] { typeof(LogType), typeof(Il2CppObject) })]
        public static bool Log(Il2CppObject __1)
        {
            try
            {
                if (__1.GetIl2CppType().ToString() == "System.String")
                {
                    switch(__1.ToString())
                    {
                        case "Trying to add Input (UnityEngine.UI.InputField) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                        case "Trying to add interact_tips (UnityEngine.UI.Image) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                        case "Trying to add SCK_tips (UnityEngine.UI.Image) for graphic rebuild while we are already inside a graphic rebuild loop. This is not supported.":
                            return false;
                    }
                }
            }
            catch (ObjectCollectedException)
            {
            }
            return true;
        }
    }
}
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using TMPro;
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
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F13),
                                    String.Format(
                                        "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha3
                                    )
                                )
                            );
                            length = 3;
                            #endregion
                            break;
                        case Characters.F14:
                            #region[Set F14 Text]
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F14),
                                    String.Format(
                                        "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha4
                                    )
                                )
                            );
                            length = 3;
                            #endregion
                            break;
                        case Characters.F15:
                            #region[Set F15 Text]
                            __instance.SetText(
                                text.Replace(
                                    GetDescriptionFromEnumValue(Characters.F15),
                                    String.Format(
                                        "<size=95%><cspace=-0.9em><sprite name=sck{0}><sprite name=sck{1}><sprite name=sck{2}></cspace></size>",
                                        (int)KeyCode.F,
                                        (int)KeyCode.Alpha1,
                                        (int)KeyCode.Alpha5
                                    )
                                )
                            );
                            length = 3;
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

                            Vector2 oldOffsetMax = transform.offsetMax;
                            transform.offsetMax = new Vector2(oldOffsetMax.x < 240 ? oldOffsetMax.x + (int)((33 * (length - 1) * 0.5)) : oldOffsetMax.x, oldOffsetMax.y);

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
}
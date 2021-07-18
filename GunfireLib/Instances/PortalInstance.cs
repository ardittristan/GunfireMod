﻿using System;
using System.Collections;
using MelonLoader;
using UnhollowerBaseLib.Attributes;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace GunfireLib.Instances
{
    public class PortalInstance : MonoBehaviour
    {

        public static GameObject Instance = null;
        public static bool portalFound = false;

        internal static void Setup()
        {
            ClassInjector.RegisterTypeInIl2Cpp<PortalInstance>();

            var obj = new GameObject("Portal");
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;
            obj.AddComponent<PortalInstance>();
        }

        public PortalInstance(IntPtr ptr) : base(ptr) { }

        internal void Awake()
        {
            MelonLogger.Msg("Starting PortalBehaviour");
            MelonCoroutines.Start(CheckPortal());
        }

        [HideFromIl2Cpp]
        private IEnumerator CheckPortal()
        {
            while (true)
            {
                var gateObjects = GameObject.FindGameObjectsWithTag(Tag.GateNPC);
                if (gateObjects.Length == 1)
                {
                    if (!portalFound)
                    {
                        Instance = gateObjects[0];
                        portalFound = true;
                        MelonLogger.Msg(Instance.name);
                    }
                }
                else
                {
                    if (portalFound)
                    {
                        Instance = null;
                        portalFound = false;
                    }
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
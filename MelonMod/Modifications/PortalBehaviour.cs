using System;
using System.Collections;
using MelonLoader;
using UnhollowerBaseLib.Attributes;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace GunfireBaseMod.Modifications
{
    class PortalBehaviour : MonoBehaviour
    {

        public GameObject WorldPortal = null;
        private bool foundPortal = false;

        internal static PortalBehaviour Instance { get; private set; }

        internal static void Setup()
        {
            ClassInjector.RegisterTypeInIl2Cpp<PortalBehaviour>();

            var obj = new GameObject("PortalBehaviour");
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;
            Instance = obj.AddComponent<PortalBehaviour>();
        }

        public PortalBehaviour(IntPtr ptr) : base(ptr) { }

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
                    if (!foundPortal)
                    {
                        WorldPortal = gateObjects[0];
                        foundPortal = true;
                        MelonLogger.Msg(WorldPortal.name);
                    }
                }
                else
                {
                    if (foundPortal)
                    {
                        WorldPortal = null;
                        foundPortal = false;
                    }
                }
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}

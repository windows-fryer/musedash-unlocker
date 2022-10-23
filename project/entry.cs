using Harmony;
using MelonLoader;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.UI;

[assembly: MelonInfo(typeof(MuseDashUnlocker.project.entry), "MuseDash Unlock All", "1.0.0", "Liga")]

namespace MuseDashUnlocker.project {
    internal class entry : MelonMod {
        public static bool patchedDlcVerify(ref bool __result)
        {
            __result = true;

            return false;
        }

        public override void OnApplicationStart()
        {
            var HarmonyPatcher = new HarmonyLib.Harmony("0c0215b2-aa0c-4ab3-9b97-2343d0b5e1df");

            HarmonyPatcher.Patch(typeof(Steamworks.SteamApps).GetMethod("BIsDlcInstalled"), new HarmonyMethod(typeof(entry), "patchedDlcVerify"));
        }
    }
}

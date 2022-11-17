using HarmonyLib;
using System;
using ProjectM;
using Settings;
using Logger;

namespace Patch;

[HarmonyPatch]

// SleepInsideSystemPatch Called when the player is inside of the coffin.
public class SleepInsideSystemPatch {
    [HarmonyPatch(typeof(SleepInsideSystem), nameof(SleepInsideSystem.OnUpdate))]
    public static class OnUpdate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                Systems.RotationCycle.IncreaseTime(__instance.EntityManager);
                Systems.Convertion.IncreaseProgress(__instance.EntityManager);
                Systems.Mission.IncreaseProgress(__instance.EntityManager);
            } catch (Exception e) { Log.Fatal(e); }
        }
    }
}
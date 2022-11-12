using HarmonyLib;
using System;
using ProjectM;
using CoffinSleep;

namespace Patch;

[HarmonyPatch]
public class SleepInsideSystemPatch {
    [HarmonyPatch(typeof(SleepInsideSystem), "OnUpdate")]
    public static class OnUpdate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                if (RotationCycle.DayNightCycle.CurrentTimeOfDay(__instance.EntityManager) != TimeOfDay.Day) {
                    return;
                }

                if (!Character.Player.IsAllSleeping(__instance.EntityManager)) {
                    return;
                }

                var increasedMinutes = 1;
                RotationCycle.Time.Increase(__instance.EntityManager, increasedMinutes);
                Servant.Station.IncreaseProgress(__instance.EntityManager, increasedMinutes);
            } catch (Exception e) {
                Console.WriteLine(e);
                Plugin.Logger.LogError(e);
            }
        }
    }
}
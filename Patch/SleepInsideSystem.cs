using HarmonyLib;
using System;
using ProjectM;
using Config;

namespace Patch;

[HarmonyPatch]
public class SleepInsideSystemPatch {
    [HarmonyPatch(typeof(SleepInsideSystem), "OnUpdate")]
    public static class OnUpdate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                if (Env.OnlyDayTimeSleep.Value) {
                    if (RotationCycle.DayNightCycle.CurrentTimeOfDay(__instance.EntityManager) != TimeOfDay.Day) {
                        return;
                    }
                }

                if (Env.OnlyAllPlayersSleeping.Value) {
                    if (!Character.Player.IsAllSleeping(__instance.EntityManager)) {
                        return;
                    }
                }

                var increasedMinutes = Env.IncreasedTime.Value;

                RotationCycle.Time.Increase(__instance.EntityManager, increasedMinutes);

                if (Env.ServantConvertionSpeeds.Value) {
                    Servant.Convertion.IncreaseProgress(__instance.EntityManager, increasedMinutes);
                }

                if (Env.ServantMissionSpeeds.Value) {
                    Servant.Mission.IncreaseProgress(__instance.EntityManager, increasedMinutes);
                }

                if (Env.ServantInjurySpeeds.Value) {
                    Servant.Injury.IncreaseProgress(__instance.EntityManager, increasedMinutes);
                }

            } catch (Exception e) {
                Log.Error(e);
            }
        }
    }
}
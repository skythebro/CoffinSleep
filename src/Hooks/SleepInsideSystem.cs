using System;
using HarmonyLib;
using ProjectM;
using Utils.Logger;
using Utils.VRising.Entities;

namespace CoffinSleep.Hooks;

[HarmonyPatch]

// SleepInsideSystemPatch Called when the player is inside of the coffin.
public class SleepInsideSystemPatch {
    [HarmonyPatch(typeof(SleepInsideSystem), nameof(SleepInsideSystem.OnCreate))]
    public static class OnCreate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                if (Bloodstone.API.VWorld.IsClient) {
                    World.Set(Bloodstone.API.VWorld.Client);
                }
                if (Bloodstone.API.VWorld.IsServer) {
                    World.Set(Bloodstone.API.VWorld.Server);
                }
            } catch (Exception e) { Log.Fatal(e); }
        }
    }

    [HarmonyPatch(typeof(SleepInsideSystem), nameof(SleepInsideSystem.OnUpdate))]
    public static class OnUpdate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                Systems.RotationCycle.IncreaseTime(
                    (int modifier) => Systems.Convertion.IncreaseProgress(modifier),
                    (int modifier) => Systems.Mission.IncreaseProgress(modifier)
                );
            } catch (Exception e) { Log.Fatal(e); }
        }
    }
}
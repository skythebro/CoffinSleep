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
                Log.Trace("SleepInsideSystem.OnCreate");
                if (Wetstone.API.VWorld.IsClient) {
                    World.Set(Wetstone.API.VWorld.Client);
                    Log.Trace("Client world set!");
                }
                if (Wetstone.API.VWorld.IsServer) {
                    World.Set(Wetstone.API.VWorld.Server);
                    Log.Trace("Server world set!");
                }
            } catch (Exception e) { Log.Fatal(e); }
        }
    }

    [HarmonyPatch(typeof(SleepInsideSystem), nameof(SleepInsideSystem.OnUpdate))]
    public static class OnUpdate {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                Log.Timed(
                    () => Log.Trace("SleepInsideSystem.OnUpdate"),
                    10000,
                    "SleepInsideSystem.OnUpdate"
                );

                Systems.RotationCycle.IncreaseTime();
                Systems.Convertion.IncreaseProgress();
                Systems.Mission.IncreaseProgress();
            } catch (Exception e) { Log.Fatal(e); }
        }
    }
}
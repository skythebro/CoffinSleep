using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;
using System;

namespace CoffinSleep;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("xyz.molenzwiebel.wetstone")]
public class Plugin : BasePlugin {
    public static ManualLogSource logger;
    HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(PluginInfo.PLUGIN_GUID);

    public override void Load() {
        // Plugin startup logic
        logger = this.Log;
        Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        harmony.PatchAll();
    }

    public override bool Unload() {
        harmony.UnpatchSelf();
        return true;
    }


    [HarmonyPatch(typeof(SleepInsideSystem), "OnUpdate")]
    public static class SleepInsideSystemOnUpdatePatch {
        private static void Prefix(SleepInsideSystem __instance) {
            try {
                if (!Player.Helper.AllPlayersSleeping(__instance.EntityManager)) {
                    return;
                }

                var increasedMinutes = 1;
                DayNightCycle.Helper.IncreaseDayTime(__instance.EntityManager, increasedMinutes);
                Servant.Station.IncreaseProgress(__instance.EntityManager, increasedMinutes);
            } catch (Exception e) {
                logger.LogError(e);
            }
        }
    }
}

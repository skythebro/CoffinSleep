using System;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;

namespace CoffinSleep;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("xyz.molenzwiebel.wetstone")]
// [Wetstone.API.Reloadable]
public class Plugin : BasePlugin {
    public static ManualLogSource Logger;
    public static Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

    public override void Load() {
        Logger = this.Log;
        Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} is loaded!");

        harmony.PatchAll();

    }

    public override bool Unload() {
        harmony.UnpatchSelf();
        Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} is unloaded!");

        return true;
    }
}

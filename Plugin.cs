using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Config;
using Wetstone.API;

namespace CoffinSleep;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("xyz.molenzwiebel.wetstone")]
// [Wetstone.API.Reloadable]
public class Plugin : BasePlugin {
    public static Harmony harmony;

    public override void Load() {
        global::Config.Log.Logger = this.Log;
        global::Config.Env.Config = this.Config;

        global::Config.Env.Load();
        global::Config.Log.Load();

        if (VWorld.IsServer) {
            harmony = new Harmony(PluginInfo.PLUGIN_GUID);

            harmony.PatchAll();

            global::Config.Log.Info($"Plugin {PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} server site is loaded!");
        }

        if (VWorld.IsClient) {
            global::Config.Log.Info($"Plugin {PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} client side is loaded!");
        }
    }

    public override bool Unload() {
        harmony.UnpatchSelf();

        global::Config.Log.Info($"Plugin {PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} is unloaded!");
        return true;
    }
}

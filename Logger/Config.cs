using CoffinSleep;
using BepInEx.Logging;
using System;
using System.IO;

namespace Logger;

public class Config {
    public static string pluginFolderPath = $"{BepInEx.Paths.ConfigPath}\\{PluginInfo.PLUGIN_GUID}";
    internal static ManualLogSource logger;
    internal static string tempLogFile;
    internal static bool logOnFile;
    internal static bool traceLevel;


    // Load the logs start configs.
    public static void Load(ManualLogSource logger, string worldType, bool logOnFile, bool traceLevel) {
        Config.logger = logger;
        Config.logOnFile = logOnFile;
        Config.traceLevel = traceLevel;

        if (!Directory.Exists(pluginFolderPath)) {
            Directory.CreateDirectory(pluginFolderPath);
        }

        tempLogFile = $"{pluginFolderPath}\\{PluginInfo.PLUGIN_GUID}-{worldType}.log";

        Log.Start($"Using \"{tempLogFile}\" to save logs.");
    }

    internal static void logFile(object data, string level, string prefix = "") {
        if (logOnFile) {
            using (StreamWriter w = File.AppendText(tempLogFile)) {
                var msg = $"{prefix}{DateTime.Now.ToString("hh:mm:ss")} [{level} {PluginInfo.PLUGIN_GUID}]: {data}";
                w.WriteLine(msg);
            }
        }
    }
}
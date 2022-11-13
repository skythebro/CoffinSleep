using BepInEx.Logging;
using System;
using System.IO;
using System.Windows;

namespace Config;

public class Log {
    public static ManualLogSource Logger;
    private static string TempLogFile;

    public static void Load() {
        if (Env.LogOnTempFile.Value) {
            TempLogFile = $"{System.IO.Path.GetTempPath()}{Guid.NewGuid().ToString()}-{CoffinSleep.PluginInfo.PLUGIN_GUID}.log";
            Message($"Using \"{TempLogFile}\" to save logs.");
        }
    }

    public static void Info(object data) {
        Logger.LogInfo(data);
        logOnFile(data, "Info   ");
    }

    public static void Error(object data) {
        Logger.LogError(data);
        logOnFile(data, "Error  ");
    }

    public static void Debug(object data) {
        Logger.LogDebug(data);
        logOnFile(data, "Debug  ");
    }

    public static void Fatal(object data) {
        Logger.LogFatal(data);
        logOnFile(data, "Fatal  ");
    }

    public static void Warning(object data) {
        Logger.LogWarning(data);
        logOnFile(data, "Warning");
    }

    public static void Message(object data) {
        Logger.LogMessage(data);
        logOnFile(data, "Message");
    }

    private static void logOnFile(object data, string prefix) {
        if (Env.LogOnTempFile.Value) {
            using (StreamWriter w = File.AppendText(TempLogFile)) {
                var msg = $"[{CoffinSleep.PluginInfo.PLUGIN_GUID}: {prefix}]: {data}";
                w.WriteLine(msg);
            }
        }
    }
}
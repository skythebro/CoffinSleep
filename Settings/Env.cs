using BepInEx.Configuration;

namespace Settings;

public class Env {
    // SERVER
    public static ConfigEntry<int> IncreasedTime;
    public static ConfigEntry<bool> OnlyDayTimeSleep;
    public static ConfigEntry<bool> OnlyAllPlayersSleeping;
    public static ConfigEntry<bool> ServantConvertionSpeeds;
    public static ConfigEntry<bool> ServantMissionSpeeds;

    // DEBUG
    public static ConfigEntry<bool> LogOnTempFile;
    public static ConfigEntry<bool> EnableTraceLogs;

    // Load the plugin config variables.
    public static void load() {
        // Server
        IncreasedTime = Config.cfg.Bind(
            "Server",
            "IncreasedTime",
            1,
            "Change the increased time change by frame"
        );

        OnlyDayTimeSleep = Config.cfg.Bind(
            "Server",
            "OnlyDayTimeSleep",
            true,
            "Enabled, sleep just speeds the time when it's daytime"
        );

        OnlyAllPlayersSleeping = Config.cfg.Bind(
            "Server",
            "OnlyAllPlayersSleeping",
            true,
            "Enabled, sleep just speeds the time if all players of the server are sleeping"
        );

        ServantConvertionSpeeds = Config.cfg.Bind(
            "Server",
            "ServantConvertionSpeeds",
            true,
            "Enabled, sleep speeds servant convertion progress"
        );

        ServantMissionSpeeds = Config.cfg.Bind(
            "Server",
            "ServantMissionSpeeds",
            true,
            "Enabled, sleep speeds servant mission progress"
        );

        // Ðebug
        LogOnTempFile = Config.cfg.Bind(
            "Ðebug",
            "LogOnTempFile",
            false,
            "Enabled, will log every plugin log on a temp file"
        );

        EnableTraceLogs = Config.cfg.Bind(
            "Ðebug",
            "EnableTraceLogs",
            false,
            "Enabled, will print Trace logs (Debug output in BepInEx)"
        );

        validateValues();
    }

    private static void validateValues() {
        Config.cfg.Save();
    }
}

using BepInEx.Configuration;

namespace Config;

public class Env {
    public static ConfigFile Config;
    public static ConfigEntry<int> IncreasedTime;
    public static ConfigEntry<bool> OnlyDayTimeSleep;
    public static ConfigEntry<bool> OnlyAllPlayersSleeping;
    public static ConfigEntry<bool> ServantConvertionSpeeds;
    public static ConfigEntry<bool> ServantInjurySpeeds;
    public static ConfigEntry<bool> ServantMissionSpeeds;
    public static ConfigEntry<bool> LogOnTempFile;

    public static void Load() {
        IncreasedTime = Config.Bind(
            "CoffinSleep",
            "IncreasedTime",
            1,
            "Change the increased time change by frame"
        );

        OnlyDayTimeSleep = Config.Bind(
            "CoffinSleep",
            "OnlyDayTimeSleep",
            true,
            "Enabled, sleep just passes the time when it's daytime"
        );

        OnlyAllPlayersSleeping = Config.Bind(
            "CoffinSleep",
            "OnlyAllPlayersSleeping",
            true,
            "Enabled, sleep just passes the time if all player of the server are sleeping"
        );

        ServantConvertionSpeeds = Config.Bind(
            "CoffinSleep",
            "ServantConvertionSpeeds",
            true,
            "Enabled, sleep speeds servant convertion progress"
        );

        ServantInjurySpeeds = Config.Bind(
            "CoffinSleep",
            "ServantInjurySpeeds",
            true,
            "Enabled, sleep speeds servant injury recover progress"
        );

        ServantMissionSpeeds = Config.Bind(
            "CoffinSleep",
            "ServantMissionSpeeds",
            true,
            "Enabled, sleep speeds servant mission progress"
        );

        LogOnTempFile = Config.Bind(
            "Debug",
            "LogOnTempFile",
            false,
            "Enabled, will log every plugin log on a temp file"
        );
    }
}

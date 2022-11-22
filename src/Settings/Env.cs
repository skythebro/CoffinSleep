using BepInEx.Configuration;

namespace CoffinSleep.Settings;

public class ENV {
    // Server
    public static ConfigEntry<int> IncreasedTime;
    public static ConfigEntry<bool> OnlyDayTimeSleep;
    public static ConfigEntry<bool> OnlyAllPlayersSleeping;
    public static ConfigEntry<bool> ServantConvertionSpeeds;
    public static ConfigEntry<bool> ServantMissionSpeeds;

    public class Server {
        private static string serverSection = "🔧Server";

        public static void Setup() {
            Utils.Settings.Config.AddConfigActions(load);
        }

        // Load the plugin config variables.
        public static void load() {
            // Server
            IncreasedTime = Utils.Settings.Config.cfg.Bind(
                serverSection,
                nameof(IncreasedTime),
                1,
                "Change the increased time change by frame"
            );

            OnlyDayTimeSleep = Utils.Settings.Config.cfg.Bind(
                serverSection,
                nameof(OnlyDayTimeSleep),
                true,
                "Enabled, sleep just speeds the time when it's daytime"
            );

            OnlyAllPlayersSleeping = Utils.Settings.Config.cfg.Bind(
                serverSection,
                nameof(OnlyAllPlayersSleeping),
                true,
                "Enabled, sleep just speeds the time if all players of the server are sleeping"
            );

            ServantConvertionSpeeds = Utils.Settings.Config.cfg.Bind(
                serverSection,
                nameof(ServantConvertionSpeeds),
                true,
                "Enabled, sleep speeds servant convertion progress"
            );

            ServantMissionSpeeds = Utils.Settings.Config.cfg.Bind(
                serverSection,
                nameof(ServantMissionSpeeds),
                true,
                "Enabled, sleep speeds servant mission progress"
            );
        }
    }
}

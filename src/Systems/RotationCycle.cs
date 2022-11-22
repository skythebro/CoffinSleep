using CoffinSleep.Settings;
using Utils.VRising.Entities;

namespace CoffinSleep.Systems;

public static class RotationCycle {
    public static void IncreaseTime() {
        if (ENV.OnlyDayTimeSleep.Value && !DayNightCycle.IsDay()) {
            return;
        }

        if (User.IsAllOffline()) {
            return;
        }

        if (ENV.OnlyAllPlayersSleeping.Value && !PlayerCharacter.IsAllOnlinePlayersSleeping()) {
            return;
        }

        SetTimeOfDayEvent.Add(minute: ENV.IncreasedTime.Value);
    }
}

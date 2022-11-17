using Unity.Entities;
using Settings;
using Entities;

namespace Systems;

public static class RotationCycle {
    public static void IncreaseTime(EntityManager em) {
        if (Env.OnlyDayTimeSleep.Value && !DayNightCycle.IsDay(em)) {
            return;
        }

        if (User.IsAllOffline(em)) {
            return;
        }

        if (Env.OnlyAllPlayersSleeping.Value && !isAllPlayersSleeping(em)) {
            return;
        }

        SetTimeOfDayEvent.Add(em, minute: Env.IncreasedTime.Value);
    }

    private static bool isAllPlayersSleeping(EntityManager em) {
        var sleepingEntities = Sleeping.Get(em);
        var playerEntities = PlayerCharacter.Get(em);

        foreach (var playerEntity in playerEntities) {
            // Offline players outside coffin is not considered sleeping
            if (!PlayerCharacter.IsOnline(em, playerEntity)) {
                continue;
            }

            if (!Sleeping.HasTarget(em, sleepingEntities, playerEntity)) {
                return false;
            }
        }
        return true;
    }
}

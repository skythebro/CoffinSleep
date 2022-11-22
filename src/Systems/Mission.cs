using CoffinSleep.Settings;
using Utils.VRising.Entities;

namespace CoffinSleep.Systems;

public static class Mission {
    // IncreaseProgress of servant missions.
    public static void IncreaseProgress() {
        if (!ENV.ServantMissionSpeeds.Value) {
            return;
        }

        var missions = ActiveServantMission.GetAllBuffers();
        foreach (var missionBuffer in missions) {
            for (int i = 0; i < missionBuffer.Length; i++) {
                var mission = missionBuffer[i];

                var newMissionLength = ActiveServantMission.GetMissionLength(mission) - ENV.IncreasedTime.Value;
                if (newMissionLength <= 0) {
                    newMissionLength = 0;
                }

                ActiveServantMission.SetMissionLength(ref mission, newMissionLength);
                missionBuffer[i] = mission;
            }
        }
    }
}

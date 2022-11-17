using Unity.Entities;
using Settings;

namespace Systems;

public static class Mission {
    // IncreaseProgress of servant missions.
    public static void IncreaseProgress(EntityManager em) {
        if (!Env.ServantMissionSpeeds.Value) {
            return;
        }

        var missionEntities = Entities.ActiveServantMission.Get(em);

        foreach (var missionEntity in missionEntities) {
            var missionBuffer = Entities.ActiveServantMission.GetBuffer(em, missionEntity);

            for (int i = 0; i < missionBuffer.Length; i++) {
                var mission = missionBuffer[i];
                mission.MissionLength -= Env.IncreasedTime.Value;
                if (mission.MissionLength <= 0) {
                    mission.MissionLength = 0;
                }
                missionBuffer[i] = mission;
            }
        }
    }
}

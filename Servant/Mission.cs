using ProjectM;
using Unity.Entities;

namespace Servant;

public static class Mission {
    public static Unity.Collections.NativeArray<Entity> GetEntities(EntityManager em) {
        var servantMissionsQuery = em.CreateEntityQuery(
                ComponentType.ReadWrite<ActiveServantMission>()
            );
        return servantMissionsQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
    }

    public static void IncreaseProgress(EntityManager em, int minutes) {
        var missionEntities = GetEntities(em);

        foreach (var missionEntity in missionEntities) {
            var missionBuffer = em.GetBuffer<ActiveServantMission>(missionEntity);

            for (int i = 0; i < missionBuffer.Length; i++) {
                var mission = missionBuffer[i];
                mission.MissionLength -= minutes;
                missionBuffer[i] = mission;
            }
        }
    }
}

using Unity.Entities;
using Unity.Collections;

namespace Entities;

public static class ActiveServantMission {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadWrite<ProjectM.ActiveServantMission>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static DynamicBuffer<ProjectM.ActiveServantMission> GetBuffer(EntityManager em, Entity mission) {
        return em.GetBuffer<ProjectM.ActiveServantMission>(mission);
    }
}
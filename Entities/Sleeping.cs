using Unity.Entities;
using Unity.Collections;

namespace Entities;

public static class Sleeping {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Buff>(),
            ComponentType.ReadOnly<ProjectM.SpawnSleepingBuff>(),
            ComponentType.ReadOnly<ProjectM.InsideBuff>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static bool HasTarget(EntityManager em, NativeArray<Entity> sleepingEntities, Entity target) {
        foreach (var sleepingEntity in sleepingEntities) {
            var buff = em.GetComponentData<ProjectM.Buff>(sleepingEntity);
            if (buff.Target == target) {
                return true;
            }
        }
        return false;
    }
}
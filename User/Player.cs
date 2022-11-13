using Unity.Entities;
using Unity.Collections;
using ProjectM;

namespace User;

public static class Player {
    // GetEntities of component type PlayerCharacter
    public static NativeArray<Entity> GetEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<PlayerCharacter>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // GetSleepingEntities is used to get all possible player targets from sleeping buff.
    public static NativeArray<Entity> GetSleepingEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<Buff>(),
            ComponentType.ReadOnly<SpawnSleepingBuff>(),
            ComponentType.ReadOnly<InsideBuff>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsSleeping check if an sleeping buff target the player.
    public static bool IsSleeping(EntityManager em, Entity player, NativeArray<Entity> sleepingEntities) {
        foreach (var sleepingEntity in sleepingEntities) {
            var buff = em.GetComponentData<Buff>(sleepingEntity);
            if (buff.Target == player) {
                return true;
            }
        }
        return false;
    }

    // IsAllSleeping check if all online players are sleeping.
    public static bool IsAllSleeping(EntityManager em) {
        var sleepingEntities = GetSleepingEntities(em);
        var playerEntities = GetEntities(em);

        foreach (var playerEntity in playerEntities) {
            // Offline players outside coffin is not considered sleeping
            if (Info.IsOffline(em, playerEntity)) {
                continue;
            }

            if (!IsSleeping(em, playerEntity, sleepingEntities)) {
                return false;
            }
        }
        return true;
    }
}

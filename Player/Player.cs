using ProjectM;
using Unity.Entities;

namespace Player;

public static class Helper {
    // Whether a player is sleeping is separate to the player Entity itself.
    // Instead, it exists in the form of an Entity with an associated Buff, SpawnSleepingBuff and InsideBuff.
    public static Unity.Collections.NativeArray<Entity> GetSleepingEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<Buff>(),
            ComponentType.ReadOnly<SpawnSleepingBuff>(),
            ComponentType.ReadOnly<InsideBuff>()
        );
        return query.ToEntityArray(Unity.Collections.Allocator.Temp);
    }

    // A player Entity is one with an associated PlayerCharacter component
    public static Unity.Collections.NativeArray<Entity> GetPlayerEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<PlayerCharacter>()
        );
        return query.ToEntityArray(Unity.Collections.Allocator.Temp);
    }

    public static bool IsPlayerSleeping(EntityManager em, Entity player, Unity.Collections.NativeArray<Entity> sleepingEntities) {
        foreach (var sleepingEntity in sleepingEntities) {
            var buff = em.GetComponentData<Buff>(sleepingEntity);
            if (buff.Target == player) {
                return true;
            }
        }
        return false;
    }

    // Tests whether all players are sleeping by looping through the list of player entities and checking if there is a sleeping Buff component that references their Entity as the target
    public static bool AllPlayersSleeping(EntityManager em) {
        var sleepingEntities = GetSleepingEntities(em);
        var players = GetPlayerEntities(em);

        foreach (var player in players) {
            if (!IsPlayerSleeping(em, player, sleepingEntities)) {
                return false;
            }
        }
        return true;
    }
}

using Unity.Entities;
using Unity.Collections;
using ProjectM;
using ProjectM.Network;

namespace Character;

public static class Info {
    // GetEntities of component type User
    public static NativeArray<Entity> GetEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<User>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsOffline check if an user is offline based on passed player entity.
    public static bool IsOffline(EntityManager em, Entity playerEntity) {
        var player = em.GetComponentData<PlayerCharacter>(playerEntity);
        var user = em.GetComponentData<User>(player.UserEntity._Entity);
        return !user.IsConnected;
    }
}

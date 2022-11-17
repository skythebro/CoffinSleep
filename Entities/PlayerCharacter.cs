using Unity.Entities;
using Unity.Collections;

namespace Entities;

public static class PlayerCharacter {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.PlayerCharacter>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsOffline check if an user is offline based on passed player entity.
    public static bool IsOnline(EntityManager em, Entity playerCharacter) {
        var player = em.GetComponentData<ProjectM.PlayerCharacter>(playerCharacter);
        var user = em.GetComponentData<ProjectM.Network.User>(player.UserEntity._Entity);
        return user.IsConnected;
    }
}
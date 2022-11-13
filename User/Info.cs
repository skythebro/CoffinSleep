using Unity.Entities;
using Unity.Collections;
using ProjectM;

namespace User;

public static class Info {
    // GetEntities of component type User
    public static NativeArray<Entity> GetEntities(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.User>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsOffline check if an user is offline based on passed player entity.
    public static bool IsOffline(EntityManager em, Entity playerEntity) {
        var player = em.GetComponentData<PlayerCharacter>(playerEntity);
        var user = em.GetComponentData<ProjectM.Network.User>(player.UserEntity._Entity);
        return !user.IsConnected;
    }

    // IsAllOffline check if all users are offline.
    public static bool IsAllOffline(EntityManager em) {
        var userEntities = GetEntities(em);
        foreach (var userEntity in userEntities) {
            var user = em.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return false;
            }
        }
        return true;
    }
}

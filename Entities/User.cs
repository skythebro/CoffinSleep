using Unity.Entities;
using Unity.Collections;

namespace Entities;

public static class User {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.User>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsAllOffline check if all users are offline.
    public static bool IsAllOffline(EntityManager em) {
        var userEntities = Entities.User.Get(em);
        foreach (var userEntity in userEntities) {
            var user = em.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return false;
            }
        }
        return true;
    }
}
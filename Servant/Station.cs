using ProjectM;
using Unity.Entities;

namespace Servant;

public static class Station {
    public static Unity.Collections.NativeArray<Entity> GetEntities(EntityManager em) {
        var servantCoffinsQuery = em.CreateEntityQuery(
                    ComponentType.ReadWrite<ServantCoffinstation>()
                );
        return servantCoffinsQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
    }

    public static void IncreaseProgress(EntityManager em, int minutes) {
        Convertion.IncreaseProgress(em, minutes);
        Mission.IncreaseProgress(em, minutes);
        Injury.IncreaseProgress(em, minutes);
    }
}
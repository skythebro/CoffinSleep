using Unity.Entities;
using Unity.Collections;
using ProjectM;

namespace Servant;

public static class Station {
    // GetEntities of component type ServantCoffinstation.
    public static NativeArray<Entity> GetEntities(EntityManager em) {
        var servantCoffinsQuery = em.CreateEntityQuery(
                    ComponentType.ReadWrite<ServantCoffinstation>()
                );
        return servantCoffinsQuery.ToEntityArray(Allocator.Temp);
    }

    // IncreaseProgress off all servant coffin station processes.
    public static void IncreaseProgress(EntityManager em, int minutes) {
        Convertion.IncreaseProgress(em, minutes);
        Mission.IncreaseProgress(em, minutes);
        Injury.IncreaseProgress(em, minutes);
    }
}
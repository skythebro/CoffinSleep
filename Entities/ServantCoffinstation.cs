using Unity.Entities;
using Unity.Collections;

namespace Entities;

public static class ServantCoffinstation {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadWrite<ProjectM.ServantCoffinstation>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static ProjectM.ServantCoffinstation GetComponentData(EntityManager em, Entity servantCoffinStation) {
        return em.GetComponentData<ProjectM.ServantCoffinstation>(servantCoffinStation);
    }

    public static bool IsConverting(EntityManager em, ProjectM.ServantCoffinstation servantCoffinStation) {
        return servantCoffinStation.State == ProjectM.ServantCoffinState.Converting;
    }

    public static void SetComponentData(EntityManager em, Entity servantCoffinStationEntity, ProjectM.ServantCoffinstation servantCoffinStation) {
        em.SetComponentData<ProjectM.ServantCoffinstation>(servantCoffinStationEntity, servantCoffinStation);
    }
}
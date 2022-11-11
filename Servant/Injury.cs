using ProjectM;
using Unity.Entities;

namespace Servant;

public static class Injury {
    public static void IncreaseProgress(EntityManager em, int minutes) {
        var coffinEntities = Station.GetEntities(em);

        foreach (var coffinEntity in coffinEntities) {
            var coffinStation = em.GetComponentData<ServantCoffinstation>(coffinEntity);

            if (coffinStation.State == ServantCoffinState.Converting) {
                coffinStation.RecuperateEndTime -= minutes;
                em.SetComponentData<ServantCoffinstation>(coffinEntity, coffinStation);
            }
        }
    }
}
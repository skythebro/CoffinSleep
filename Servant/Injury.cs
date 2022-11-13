using Unity.Entities;
using ProjectM;

namespace Servant;

public static class Injury {
    // IncreaseProgress of servant injury.
    public static void IncreaseProgress(EntityManager em, int minutes) {
        var coffinEntities = Station.GetEntities(em);

        foreach (var coffinEntity in coffinEntities) {
            var coffinStation = em.GetComponentData<ServantCoffinstation>(coffinEntity);

            if (coffinStation.State == ServantCoffinState.Converting) {
                coffinStation.RecuperateEndTime -= minutes;
                if (coffinStation.RecuperateEndTime <= 0) {
                    coffinStation.RecuperateEndTime = 0;
                }
                em.SetComponentData<ServantCoffinstation>(coffinEntity, coffinStation);
            }
        }
    }
}
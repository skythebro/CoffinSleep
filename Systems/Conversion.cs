using Unity.Entities;
using Settings;

namespace Systems;

public static class Convertion {
    // IncreaseProgress of servant convertion.
    public static void IncreaseProgress(EntityManager em) {
        if (!Env.ServantConvertionSpeeds.Value) {
            return;
        }

        var coffinEntities = Entities.ServantCoffinstation.Get(em);

        foreach (var coffinEntity in coffinEntities) {
            var coffinStation = Entities.ServantCoffinstation.GetComponentData(em, coffinEntity);
            if (Entities.ServantCoffinstation.IsConverting(em, coffinStation)) {
                coffinStation.ConvertionProgress += Env.IncreasedTime.Value;
                Entities.ServantCoffinstation.SetComponentData(em, coffinEntity, coffinStation);
            }
        }
    }
}
using Unity.Entities;
using ProjectM.Network;

namespace RotationCycle;

public static class Time {
    // Increase the rotation cycle time
    public static void Increase(EntityManager em, int minutes) {
        var setTimeEntity = em.CreateEntity(
            ComponentType.ReadOnly<SetTimeOfDayEvent>()
        );
        em.SetComponentData<SetTimeOfDayEvent>(
            setTimeEntity,
            new SetTimeOfDayEvent() {
                Day = 0,
                Hour = 0,
                Minute = minutes,
                Month = 0,
                Year = 0,
                Type = SetTimeOfDayEvent.SetTimeType.Add
            }
        );
    }
}

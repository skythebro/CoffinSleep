using Unity.Entities;
using ProjectM.Network;

namespace DayNightCycle;

public static class Helper {
    public static void IncreaseDayTime(EntityManager em, int minutes) {
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
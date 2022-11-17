using Unity.Entities;

namespace Entities;

public static class SetTimeOfDayEvent {
    public static void Add(EntityManager em, int minute = 0, int hour = 0, int day = 0, int month = 0, int year = 0) {
        create(em, minute, hour, day, month, year, ProjectM.Network.SetTimeOfDayEvent.SetTimeType.Add);
    }

    private static void create(EntityManager em, int minute, int hour, int day, int month, int year, ProjectM.Network.SetTimeOfDayEvent.SetTimeType type) {
        var setTimeEntity = em.CreateEntity(
                    ComponentType.ReadOnly<ProjectM.Network.SetTimeOfDayEvent>()
                );
        em.SetComponentData<ProjectM.Network.SetTimeOfDayEvent>(
            setTimeEntity,
            new ProjectM.Network.SetTimeOfDayEvent() { Minute = minute, Hour = hour, Day = day, Month = month, Year = year, Type = type }
        );
    }
}
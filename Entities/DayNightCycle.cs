using Unity.Entities;
using Unity.Collections;
using ProjectM;

namespace Entities;

public static class DayNightCycle {
    public static NativeArray<Entity> Get(EntityManager em) {
        var query = em.CreateEntityQuery(
            ComponentType.ReadWrite<ProjectM.DayNightCycle>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static TimeOfDay GetTimeOfDay(EntityManager em) {
        var dayNightCycleEntities = Entities.DayNightCycle.Get(em);

        foreach (var dayNightCycleEntity in dayNightCycleEntities) {
            var dayNightCycle = em.GetComponentData<ProjectM.DayNightCycle>(dayNightCycleEntity);
            return dayNightCycle.TimeOfDay;
        }

        return TimeOfDay.All;
    }

    public static bool IsDay(EntityManager em) {
        return DayNightCycle.GetTimeOfDay(em) == ProjectM.TimeOfDay.Day;
    }
}
using Unity.Collections;
using Unity.Entities;
using ProjectM;

namespace RotationCycle;

public static class DayNightCycle {
    // GetEntities of component type DayNightCycle.
    public static NativeArray<Entity> GetEntities(EntityManager em) {
        var dayNightCycleQuery = em.CreateEntityQuery(
                ComponentType.ReadWrite<ProjectM.DayNightCycle>()
        );
        return dayNightCycleQuery.ToEntityArray(Allocator.Temp);
    }

    // CurrentTimeOfDay return the current rotation cycle time of day. (Day, Night or All)
    public static TimeOfDay CurrentTimeOfDay(EntityManager em) {
        var dayNightCycleEntities = GetEntities(em);

        foreach (var dayNightCycleEntity in dayNightCycleEntities) {
            var dayNightCycle = em.GetComponentData<ProjectM.DayNightCycle>(dayNightCycleEntity);
            return dayNightCycle.TimeOfDay;
        }

        return TimeOfDay.All;
    }
}

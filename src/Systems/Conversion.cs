using Utils.VRising.Entities;

namespace CoffinSleep.Systems;

public static class Convertion {
    // IncreaseProgress of servant convertion.
    public static void IncreaseProgress() {
        if (!Settings.ENV.ServantConvertionSpeeds.Value) {
            return;
        }

        var coffinStations = ServantCoffinstation.GetAllComponentData();
        foreach (var coffinStation in coffinStations) {
            var station = coffinStation.Value;
            if (!ServantCoffinstation.IsConverting(station)) {
                continue;
            }

            var newConvertionProgress = ServantCoffinstation.GetConvertionProgress(station) + Settings.ENV.IncreasedTime.Value;
            ServantCoffinstation.SetConvertionProgress(ref station, newConvertionProgress);
            ServantCoffinstation.SetComponentData(coffinStation.Key, station);
        }
    }
}
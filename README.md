# CoffinSleep

Coffin Sleep is a VRising mod that speeds up time while you sleep in your coffin.

## Instalation (Manual)

* Install [BepInEx](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html)
* Extract [CoffinSleep.dll](https://github.com/caioreix/CoffinSleep/releases) into (VRising client folder)/BepInEx/plugins
* [ServerLaunchFix](https://v-rising.thunderstore.io/package/Mythic/ServerLaunchFix/) recommended for in-game hosted
  games
* (Optional) If not using ServerLaunchFix, extract CoffinSleep.dll into (VRising server folder)/BepInEx/plugins

## How to use

* Just need to enter in your coffin and sleep.

## Configuration

Values can be configured at `(VRising client/server folder)/VRising/BepInEx/config/CoffinSleep.cfg`

```
[CoffinSleep]

## Change the increased time change by frame
# Setting type: Int32
# Default value: 1
IncreasedTime = 1

## Enabled, sleep just speeds the time when it's daytime
# Setting type: Boolean
# Default value: true
OnlyDayTimeSleep = true

## Enabled, sleep just speeds the time if all players of the server are sleeping
# Setting type: Boolean
# Default value: true
OnlyAllPlayersSleeping = true

## Enabled, sleep speeds servant convertion progress
# Setting type: Boolean
# Default value: true
ServantConvertionSpeeds = true

## Enabled, sleep speeds servant injury recover progress
# Setting type: Boolean
# Default value: true
ServantInjurySpeeds = true

## Enabled, sleep speeds servant mission progress
# Setting type: Boolean
# Default value: true
ServantMissionSpeeds = true
```
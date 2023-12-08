namespace Race.App;

public class RaceInfo
{
    private readonly int _speedIncreasePerMillisecondHeld = 1;
    private long _raceDurationInMs;
    private long _recordDistanceInMillimeters;

    public long WinPossibilities
    {
        get
        {
            var minimumHoldingDurationToWin = -1;
            for (var i = 0; i < _raceDurationInMs; i++)
            {
                if (GetTravelDistanceWhenHolding(i) <= _recordDistanceInMillimeters)
                    continue;

                minimumHoldingDurationToWin = i;
                break;
            }

            return _raceDurationInMs - minimumHoldingDurationToWin - minimumHoldingDurationToWin + 1;
        }
    }

    public RaceInfo(long raceDurationInMs, long recordDistanceInMillimeters)
    {
        _raceDurationInMs = raceDurationInMs;
        _recordDistanceInMillimeters = recordDistanceInMillimeters;
    }

    public long GetTravelDistanceWhenHolding(int holdingTimeInMs)
    {
        return GetBoatSpeedIfHoldingFor(holdingTimeInMs) * GetTimeLeftForRaceIfHoldingFor(holdingTimeInMs);
    }

    private long GetBoatSpeedIfHoldingFor(int holdingTimeInMs)
    {
        return holdingTimeInMs * _speedIncreasePerMillisecondHeld;
    }

    private long GetTimeLeftForRaceIfHoldingFor(int holdingTimeInMs)
    {
        var timeLeftForRace = _raceDurationInMs - holdingTimeInMs;
        return timeLeftForRace < 0 ? 0 : timeLeftForRace;
    }
}
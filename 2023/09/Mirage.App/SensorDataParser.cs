public class SensorDataParser
{
    public static SensorHistory[] Parse(string input)
    {
        return input.Split('\n').ToList().Select(SensorHistory.Create).ToArray();
    }
}
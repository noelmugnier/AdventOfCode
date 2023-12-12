public class InstabilitySensor
{
    public static int GetPartOneResult(string input)
    {
        var predictions = SensorDataParser.Parse(input);
        return predictions.Sum(s => s.NextPrediction);
    }

    public static int GetPartTwoResult(string input)
    {
        var predictions = SensorDataParser.Parse(input);
        return predictions.Sum(s => s.PreviousPrediction);
    }
}
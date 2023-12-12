public class SensorHistory
{
    public int NextPrediction => ResolveNextValues(Values);
    public int PreviousPrediction
    {
        get
        {
            var values = Values.ToList();
            values.Reverse();
            return ResolveNextValues(values);
        }
    }

    public List<int> Values { get; }

    public static SensorHistory Create(string input)
    {
        var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        return new SensorHistory(values);
    }

    private SensorHistory(List<int> values)
    {
        Values = values;
    }

    private static int ResolveNextValues(List<int> values)
    {
        var nextValues = new List<int>();
        for (var i = 0; i < values.Count - 1; i++)
        {
            var difference = values[i + 1] - values[i];
            nextValues.Add(difference);
        }

        if (values.All(v => v == 0))
            return 0;

        return ResolveNextValues(nextValues) + values.Last();
    }
}
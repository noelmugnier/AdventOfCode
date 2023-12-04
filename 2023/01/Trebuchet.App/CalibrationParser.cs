namespace Trebuchet.App;

public static class CalibrationParser
{
    public static int Parse(string rawCalibrationValue, bool searchForDigitsAsString = false)
    {
        var digits = new List<int>();
        for (var currentPosition = 0; currentPosition < rawCalibrationValue.Length; currentPosition++)
        {
            var character = rawCalibrationValue[currentPosition];
            if (char.IsDigit(character))
            {
                digits.Add(int.Parse(character.ToString()));
                continue;
            }

            if (!searchForDigitsAsString)
                continue;

            foreach (var digitMapping in DigitsMapping)
            {
                if (character == digitMapping.Value[0] &&
                    TryParseNextCharactersAsDigit(rawCalibrationValue, currentPosition, digitMapping, out var parsedDigit))
                {
                    digits.Add(parsedDigit);
                    break;
                }
            }
        }

        if (digits.Count < 1)
            return 0;

        return digits.First() * 10 + digits.Last();
    }

    private static bool TryParseNextCharactersAsDigit(string rawCalibrationValue, int currentPosition, KeyValuePair<int, string> digitMapping, out int parsedDigit)
    {
        if (currentPosition + digitMapping.Value.Length <= rawCalibrationValue.Length)
        {
            var numberAtPosition = rawCalibrationValue.Substring(currentPosition, digitMapping.Value.Length);
            parsedDigit = numberAtPosition == digitMapping.Value ? digitMapping.Key : -1;
        }
        else
            parsedDigit = -1;

        return parsedDigit > -1;
    }

    private static readonly Dictionary<int, string> DigitsMapping = new()
    {
        { 0, "zero" },
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" }
    };
}
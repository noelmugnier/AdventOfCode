public static class CardValueMapper
{
    public static char MapCardValueV1(char value)
    {
        return value switch
        {
            'T' => 'E',
            'J' => 'D',
            'Q' => 'C',
            'K' => 'B',
            'A' => 'A',
            _ => MapDigitValueToChar(value)
        };
    }

    public static char MapCardValueV2(char value)
    {
        return value switch
        {
            'T' => 'E',
            'J' => 'Z',
            'Q' => 'C',
            'K' => 'B',
            'A' => 'A',
            _ => MapDigitValueToChar(value)
        };
    }

    private static char MapDigitValueToChar(char value)
    {
        var valueToReturn = value;
        if (char.IsDigit(value))
        {
            var startingValue = 79;
            valueToReturn = (char)(startingValue - int.Parse(value.ToString()));
        }

        return valueToReturn;
    }
}
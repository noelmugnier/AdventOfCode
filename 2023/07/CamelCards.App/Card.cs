public class Card
{
    public Card(char originalValue, int version)
    {
        OriginalValue = originalValue;
        MappedValue = version == 1 ? CardValueMapper.MapCardValueV1(originalValue) : CardValueMapper.MapCardValueV2(originalValue);
    }

    public char OriginalValue { get; }
    public char MappedValue { get; }
}
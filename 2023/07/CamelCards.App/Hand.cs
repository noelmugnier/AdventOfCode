public class Hand
{
    private readonly int _version;
    private Card[] _cards;

    public string MappedValue => string.Join("", _cards.Select(c => c.MappedValue));
    public string OriginalValue => string.Join("", _cards.Select(c => c.OriginalValue));
    public int Kind => GetHandKind();

    public static Hand CreateV1(string cardsValue)
    {
        return new Hand(cardsValue.Select(c => new Card(c, 1)).ToArray(), 1);
    }

    public static Hand CreateV2(string cardsValue)
    {
        return new Hand(cardsValue.Select(c => new Card(c, 2)).ToArray(), 2);
    }

    private Hand(Card[] cards, int version)
    {
        _cards = cards;
        _version = version;
    }

    private int GetHandKind()
    {
        return _version == 1 ? HandKindResolver.ResolveV1(_cards) : HandKindResolver.ResolveV2(_cards);
    }
}
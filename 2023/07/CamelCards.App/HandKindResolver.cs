internal static class HandKindResolver
{
    public static int ResolveV1(Card[] cards)
    {
        var groupedChars = cards
            .GroupBy(c => c.OriginalValue)
            .Select(g => new { g.Key, Count = g.Count() });

        return groupedChars.Count() switch
        {
            1 => 7,
            2 => groupedChars.Any(g => g.Count == 4) ? 6 : 5,
            3 when groupedChars.Any(g => g.Count == 3) => 4,
            3 when groupedChars.Count(g => g.Count == 2) == 2 => 3,
            4 when groupedChars.Any(g => g.Count == 2) => 2,
            _ => 1
        };
    }

    public static int ResolveV2(Card[] cards)
    {
        var groupedChars = cards
            .Where(c => c.OriginalValue != 'J')
            .GroupBy(c => c.OriginalValue)
            .Select(g => new { g.Key, Count = g.Count() });

        var jokerCardsCount = cards.Count(c => c.OriginalValue == 'J');
        if (jokerCardsCount == 0)
            return ResolveV1(cards);

        var groupedCharactersCount = groupedChars.Count();
        if (groupedCharactersCount <= 1)
            return 7;

        switch (jokerCardsCount)
        {
            case >= 2 when groupedCharactersCount == 2:
            case >= 1 when groupedCharactersCount == 2 && groupedChars.Any(g => g.Count == 3):
                return 6;
        }

        return groupedCharactersCount switch
        {
            2 => 5,
            3 => 4,
            _ => 2
        };
    }
}
namespace Scratchcards.App;

public class ScratchCardGameResolver
{
    private readonly List<ScratchCard> _scratchCards;

    public ScratchCardGameResolver(string input)
    {
        _scratchCards = ScratchCardParser.ParseAll(input).ToList();
    }

    public int TotalPoints => _scratchCards.Sum(c => c.Points);

    public int TotalScratchCards => GetScratchCardsCount();

    private int GetScratchCardsCount()
    {
        var scratchCardsGroupedByIdCount = new Dictionary<int, int>();
        for (var scratchCardsIndex = 0; scratchCardsIndex < _scratchCards.Count; scratchCardsIndex++)
            DiscoverMatchingCardsTree(scratchCardsGroupedByIdCount, scratchCardsIndex,
                _scratchCards[scratchCardsIndex].MatchingNumbers.Length);


        return scratchCardsGroupedByIdCount.Sum(c => c.Value) + _scratchCards.Count;
    }

    private void DiscoverMatchingCardsTree(IDictionary<int, int> dictionary, int parentScratchCardPosition,
        int numberOfNextScratchCardsToAdd)
    {
        for (var j = 0; j < numberOfNextScratchCardsToAdd; j++)
        {
            var scratchCard = _scratchCards[parentScratchCardPosition + 1 + j];
            if (dictionary.ContainsKey(scratchCard.Id))
                dictionary[scratchCard.Id]++;
            else
                dictionary.Add(scratchCard.Id, 1);

            DiscoverMatchingCardsTree(dictionary, parentScratchCardPosition + 1 + j,
                scratchCard.MatchingNumbers.Length);
        }
    }
}
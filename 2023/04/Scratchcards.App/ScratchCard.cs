namespace Scratchcards.App;

public class ScratchCard
{
    public int Id { get; }
    public int[] WinningNumbers { get; }
    public int[] PlayedNumbers { get; }
    public int[] MatchingNumbers => PlayedNumbers.Intersect(WinningNumbers).ToArray();

    public int Points
    {
        get
        {
            var counts = MatchingNumbers.Length;
            if (counts > 1)
                return (int)Math.Pow(2, counts - 1);

            return counts > 0 ? 1 : 0;
        }
    }

    public ScratchCard(int id, int[] winningNumbers, int[] playedNumbers)
    {
        Id = id;
        WinningNumbers = winningNumbers;
        PlayedNumbers = playedNumbers;
    }
}
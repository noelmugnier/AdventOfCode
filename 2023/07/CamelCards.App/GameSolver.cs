public class GameSolver
{
    private readonly Game[] _games;
    public int Total => SolveTotal();

    public static GameSolver CreateV1(string input)
    {
        var rawGames = input.Split('\n');
        var games = rawGames.Select(rawGame => Game.CreateGameV1(rawGame)).ToArray();
        return new GameSolver(games);
    }

    public static GameSolver CreateV2(string input)
    {
        var rawGames = input.Split('\n');
        var games = rawGames.Select(rawGame => Game.CreateGameV2(rawGame)).ToArray();
        return new GameSolver(games);
    }

    private GameSolver(Game[] games)
    {
        _games = games;
    }

    private int SolveTotal()
    {
        var orderedGames = _games.OrderBy(g => g.Hand.Kind).ThenByDescending(g => g.Hand.MappedValue)
            .Select(g => g.Bid).ToArray();
        return orderedGames.Select((bid, rank) => bid * (rank + 1)).Sum();
    }
}
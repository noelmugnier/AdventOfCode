namespace Cube.App;

public record Set(int RedCount, int GreenCount, int BlueCount);

public class GameV1
{
    private readonly int _redLimit;
    private readonly int _greenLimit;
    private readonly int _blueLimit;

    private int _id;
    public Set[] Sets { get; }

    public int Power => Sets.All(s => s.RedCount <= _redLimit && s.GreenCount <= _greenLimit && s.BlueCount <= _blueLimit) ? _id : 0;

    public GameV1(string rawGameData, int redLimit, int greenLimit, int blueLimit)
    {
        _redLimit = redLimit;
        _greenLimit = greenLimit;
        _blueLimit = blueLimit;

        var (gameId, sets) = GameParser.ParseRawData(rawGameData);
        _id = gameId;
        Sets = sets;
    }
}
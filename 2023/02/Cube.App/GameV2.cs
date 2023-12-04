namespace Cube.App;

public class GameV2
{
    public Set[] Sets { get; }

    public int Power
    {
        get
        {
            var minRed = Sets.Max(s => s.RedCount);
            var minGreen = Sets.Max(s => s.GreenCount);
            var minBlue = Sets.Max(s => s.BlueCount);

            return minRed * minGreen * minBlue;
        }
    }

    public GameV2(string rawGameData)
    {
        var (_, sets) = GameParser.ParseRawData(rawGameData);
        Sets = sets;
    }
}
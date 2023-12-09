public class Game
{
    public Hand Hand { get; }
    public int Bid { get; }

    public static Game CreateGameV1(string rawGameData)
    {
        var rawGame = rawGameData.Split(' ');
        var cards = rawGame[0];
        var bid = int.Parse(rawGame[1]);
        var hand = Hand.CreateV1(cards);
        return new Game(hand, bid);
    }

    public static Game CreateGameV2(string rawGameData)
    {
        var rawGame = rawGameData.Split(' ');
        var cards = rawGame[0];
        var bid = int.Parse(rawGame[1]);
        var hand = Hand.CreateV2(cards);
        return new Game(hand, bid);
    }

    private Game(Hand hand, int bid)
    {
        Hand = hand;
        Bid = bid;
    }
}
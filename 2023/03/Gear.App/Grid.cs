namespace Gear.App;

public record Grid(List<Symbol> Symbols, List<Number> AllNumbers)
{
    public List<int> PartNumbers => AllNumbers.Where(number => number.IsAdjacentToASymbol(Symbols))
        .Select(number => number.Value).ToList();

    public List<int> GearValues => Symbols.Select(symbol => symbol.GetValueForNumbers(AllNumbers))
        .Where(value => value > 0).ToList();
}

public record Number(int Value, int X, int Y)
{
    private int Length => Value.ToString().Length;

    public bool IsAdjacentToASymbol(IEnumerable<Symbol> symbols) => symbols.Any(IsAdjacentToSymbol);

    public bool IsAdjacentToSymbol(Symbol symbol)
    {
        var isAdjacent = false;
        for (var i = 0; i < Length; i++)
        {
            isAdjacent = IsAdjacentFromPosition(symbol, i);
            if (isAdjacent)
                break;
        }

        return isAdjacent;
    }

    private bool IsAdjacentFromPosition(Symbol symbol, int i)
    {
        var isAdjacent = false;
        if (i == 0)
            isAdjacent = IsAdjacentFromLeft(symbol);

        isAdjacent = isAdjacent || IsAdjacentFromTopOrBottom(symbol, i);

        if (i == Length - 1)
            isAdjacent = isAdjacent || IsAdjacentFromRight(symbol);

        return isAdjacent;
    }

    private bool IsAdjacentFromTopOrBottom(Symbol symbol, int i)
    {
        return symbol.X == X - 1 && symbol.Y == Y + i
               || symbol.X == X + 1 && symbol.Y == Y + i;
    }

    private bool IsAdjacentFromRight(Symbol symbol)
    {
        return symbol.X == X && symbol.Y == Y + Length
               || symbol.X == X - 1 && symbol.Y == Y + Length
               || symbol.X == X + 1 && symbol.Y == Y + Length;
    }

    private bool IsAdjacentFromLeft(Symbol symbol)
    {
        return symbol.X == X && symbol.Y == Y - 1
               || symbol.X == X - 1 && symbol.Y == Y - 1
               || symbol.X == X + 1 && symbol.Y == Y - 1;
    }
}

public record Symbol(char Value, int X, int Y)
{
    public int GetValueForNumbers(IEnumerable<Number> numbers)
    {
        if (Value != '*')
            return 0;

        var adjacentNumbers = numbers.Where(number => number.IsAdjacentToSymbol(this)).ToList();
        if (adjacentNumbers.Count != 2)
            return 0;

        return adjacentNumbers[0].Value * adjacentNumbers[1].Value;
    }
}
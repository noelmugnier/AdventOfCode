namespace Gear.App;

public static class GridParser
{
    public static Grid Parse(char[][] input)
    {
        var numbers = new List<Number>();
        var symbols = new List<Symbol>();
        for (var i = 0; i < input.Length; i++)
        {
            int? numberStartingPosition = null;
            var numberToParse = string.Empty;
            var row = input[i];
            for (var j = 0; j < row.Length; j++)
            {
                var cellValue = row[j];
                if (!char.IsDigit(cellValue) && cellValue != '.')
                {
                    symbols.Add(new Symbol(cellValue, i, j));
                }

                if (char.IsDigit(cellValue))
                {
                    numberStartingPosition ??= j;
                    numberToParse += cellValue;
                }

                if (!numberStartingPosition.HasValue || (char.IsDigit(cellValue) && j != row.Length - 1))
                    continue;

                numbers.Add(new Number(int.Parse(numberToParse), i, numberStartingPosition.Value));
                numberStartingPosition = null;
                numberToParse = string.Empty;
            }
        }

        return new Grid(symbols, numbers);
    }
}
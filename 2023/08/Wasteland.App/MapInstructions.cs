using System.Text.RegularExpressions;

namespace Wasteland.App;

public class MapInstructions
{
    public static MapInstructions Parse(string input)
    {
        var lines = input.Split("\n");
        var regex = new Regex(@"(?<origin>\w+) = \((?<left>\w+), (?<right>\w+)\)");
        var directions = new Dictionary<string, (string Left, string Right)>();
        foreach (var line in Enumerable.Range(2, lines.Length - 2))
        {
            var match = regex.Match(lines[line]);
            if (!match.Success) continue;

            var origin = match.Groups["origin"].Value;
            var left = match.Groups["left"].Value;
            var right = match.Groups["right"].Value;
            directions.Add(origin, (left, right));
        }

        return new MapInstructions(lines[0], directions);
    }

    private MapInstructions(string movements, Dictionary<string, (string Left, string Right)> directions)
    {
        Directions = directions;
        NextMovements = movements.ToCharArray();
    }

    public char[] NextMovements { get; }
    public Dictionary<string, (string Left, string Right)> Directions { get; }
    public long RequiredChoicesToReachDestination => GetStepsCountToReachDestination();
    public long RequiredChoicesToReachDestinationAsGhost => GetStepsCountToReachDestinationAsGhost();

    private long GetStepsCountToReachDestination()
    {
        var stepsCount = 0;
        var currentPosition = Directions["AAA"];
        if (!Directions.TryGetValue("ZZZ", out var value))
            return 0;

        var movementIndex = 0;
        while (currentPosition != value)
        {
            if (movementIndex == NextMovements.Length)
                movementIndex = 0;

            var nextMovement = NextMovements[movementIndex++];
            currentPosition = nextMovement switch
            {
                'R' => Directions[currentPosition.Right],
                'L' => Directions[currentPosition.Left],
                _ => throw new InvalidOperationException()
            };

            stepsCount++;
        }

        return stepsCount;
    }

    private long GetStepsCountToReachDestinationAsGhost()
    {
        var startPatterns = Directions
            .Where(d => d.Key.EndsWith("A"))
            .Select(d => d.Key)
            .ToList();

        var lcm = 1L;
        var requiredSteps = new List<long>();
        startPatterns.ForEach(pattern =>
        {
            var steps = GetStepsCountToReachDestination(pattern);
            requiredSteps.Add(steps);
            lcm *= GetLowestPrimeFactorForNumber(steps);
        });

        var gcd = requiredSteps.Aggregate(GetGreatestCommonDivisorForNumber);
        return lcm * gcd;
    }

    private static long GetLowestPrimeFactorForNumber(long number)
    {
        var results = new List<int>();
        for (var b = 2; number > 1; b++)
        {
            while (number % b == 0)
            {
                number /= b;
                results.Add(b);
            }
        }

        return results.Min();
    }

    private static long GetGreatestCommonDivisorForNumber(long a, long b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    private long GetStepsCountToReachDestination(string startPattern)
    {
        var currentPosition = Directions[startPattern];

        var movementIndex = 0;
        var stepsCount = 0;
        while (true)
        {
            stepsCount++;
            if (movementIndex == NextMovements.Length)
                movementIndex = 0;

            var nextMovement = NextMovements[movementIndex++];
            if ((currentPosition.Left.EndsWith("Z") && nextMovement == 'L') ||
                (currentPosition.Right.EndsWith("Z") && nextMovement == 'R'))
            {
                break;
            }

            currentPosition = nextMovement switch
            {
                'R' => Directions[currentPosition.Right],
                'L' => Directions[currentPosition.Left],
                _ => throw new InvalidOperationException()
            };
        }

        return stepsCount;
    }
}
using Scratchcards.App;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();
var cardGameResolver = new ScratchCardGameResolver(input);

Console.WriteLine($"First exercise: {cardGameResolver.TotalPoints}");
Console.WriteLine($"Second exercise: {cardGameResolver.TotalScratchCards}");
using Trebuchet.App;

using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var firstExerciseResult = 0;
var secondExerciseResult = 0;
while (!fsReader.EndOfStream)
{
    var rawCalibrationValue = fsReader.ReadLine();
    firstExerciseResult += CalibrationParser.Parse(rawCalibrationValue!);
    secondExerciseResult += CalibrationParser.Parse(rawCalibrationValue!, true);
}

Console.WriteLine($"First exercise: {firstExerciseResult}");
Console.WriteLine($"Second exercise: {secondExerciseResult}");
Console.ReadLine();
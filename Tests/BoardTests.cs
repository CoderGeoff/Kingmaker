using Kingmaker.Engine.Board;
using NUnit.Framework;

namespace Tests;

public class BoardTests
{
    [TestCase(1, "2(0), 5(0), 6(0)")]
    [TestCase(2, "1(0), 3(0), 5(0), 6(0), 7(0)")]
    [TestCase(6, "1(0), 2(0), 3(0), 5(0), 7(0), 9(0), 10(0), 11(0)")]
    public void GivenASimpleBoard_Travel1Space_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = Enumerable.Range(1, 20).Select(id => new Tile(id)).ToArray();

        var board = new BoardBuilder().WithTiles(tiles).WithLayout([(1, [2, 5, 6]),
                                                                    (2, [3, 5, 6, 7]),
                                                                    (3, [4, 6, 7, 8]),
                                                                    (4, [7, 8]),
                                                                    (5, [6, 9, 10]),
                                                                    (6, [7, 9, 10, 11]),
                                                                    (7, [8, 10, 11, 12]),
                                                                    (8, [11, 12]),
                                                                    (9, [10]),
                                                                    (10, [11]),
                                                                    (11, [12])])
                                      .Build();
        var start = board.GetTile(startingTile);
        var destinations = start.Travel(1);
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    [TestCase(1, "2(1), 3(0), 5(1), 6(1), 7(0), 9(0), 10(0), 11(0)")]
    [TestCase(6, "1(1), 2(1), 3(1), 4(0), 5(1), 7(1), 8(0), 9(1), 10(1), 11(1), 12(0)")]
    public void GivenASimpleBoard_Travel2Spaces_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = Enumerable.Range(1, 20).Select(id => new Tile(id)).ToArray();

        var board = new BoardBuilder().WithTiles(tiles).WithLayout([(1, [2, 5, 6]),
                                                                    (2, [3, 5, 6, 7]),
                                                                    (3, [4, 6, 7, 8]),
                                                                    (4, [7, 8]),
                                                                    (5, [6, 9, 10]),
                                                                    (6, [7, 9, 10, 11]),
                                                                    (7, [8, 10, 11, 12]),
                                                                    (8, [11, 12]),
                                                                    (9, [10]),
                                                                    (10, [11]),
                                                                    (11, [12])])
                                      .Build();
        var start = board.GetTile(startingTile);
        var destinations = start.Travel(2);
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    private static string AsString(IEnumerable<(Tile destination, int distanceLeft)> destinations)
    {
        return destinations.Select(d => $"{d.destination.Id}({d.distanceLeft})").ToCommaSeparatedList();
    }
}

public static class StringExtensions
{
    public static string ToCommaSeparatedList(this IEnumerable<string> strings)
    {
        return string.Join(", ", strings);
    }
}
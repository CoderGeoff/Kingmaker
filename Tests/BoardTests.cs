﻿using Kingmaker.Engine;
using Kingmaker.Engine.Board;
using Kingmaker.Engine.Constants;
using Kingmaker.Engine.Rules;
using NUnit.Framework;
using Place = Kingmaker.Engine.Board.Place;

namespace Tests;

public class BoardTests
{
    [TestCase(1, "2(0), 5(0), 6(0)")]
    [TestCase(2, "1(0), 3(0), 5(0), 6(0), 7(0)")]
    [TestCase(6, "1(0), 2(0), 3(0), 5(0), 7(0), 9(0), 10(0), 11(0)")]
    public void GivenASimpleBoard_PossibleDestinationsWith1Space_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = new TileBuilder()
                   .WithLayout([(1, [2, 5, 6]),
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

        var places = new PlaceBuilder().Build();
        var roads = new RoadNetworkBuilder(tiles, places).Build();
        var board = new Board(tiles, new Dictionary<Names.Place, Place>(), roads);
        var start = board.GetTile(startingTile);
        var destinations = board.PossibleDestinations(new Faction(), start, 1, new ClassicMovementRules());
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    [TestCase(1, "2(1), 3(0), 5(1), 6(1), 7(0), 9(0), 10(0), 11(0)")]
    [TestCase(6, "1(1), 2(1), 3(1), 4(0), 5(1), 7(1), 8(0), 9(1), 10(1), 11(1), 12(0)")]
    public void GivenASimpleBoard_PossibleDestinationsWith2Spaces_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = new TileBuilder()
                   .WithLayout([(1, [2, 5, 6]),
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

        var places = new PlaceBuilder().Build();
        var roads = new RoadNetworkBuilder(tiles, places).Build();
        var board = new Board(tiles, new Dictionary<Names.Place, Place>(), roads);
        var start = board.GetTile(startingTile);
        var destinations = board.PossibleDestinations(new Faction(), start, 2, new ClassicMovementRules());
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    [TestCase(1, "2(0), 7(0), 12(0)")]
    [TestCase(7, "1(0), 2(0), 12(0)")]
    public void GivenABoardWithARoadButNoAdjacentSpaces_PossibleDestinations_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = new TileBuilder().WithLayout((12, [])).Build();
        
        var places = new PlaceBuilder().With(Names.Place.Wells, PlaceAttributes.TownWithCathedral, tiles[2])
                                       .With(Names.Place.Coventry, PlaceAttributes.City, tiles[1])
                                       .Build();

        var roads = new RoadNetworkBuilder(tiles, places).BuildRoad(1, Names.Place.Coventry, 2).BuildRoad(2, 7).BuildRoad(7, 12).Build();

        var board = new Board(tiles, places, roads);
        var start = board.GetTile(startingTile);
        var destinations = board.PossibleDestinations(new Faction(), start, 1, new ClassicMovementRules());
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    [TestCase(1, "2(0), 5(0)")] 
    [TestCase(7, "1(0), 2(0), 5(0), 12(0)")]
    public void GivenABoardWithARoadThroughAnOpponentsCastle_PossibleDestinations_ShouldReturnTheExpectedDestinations(int startingTile, string expectedDestinations)
    {
        var tiles = new TileBuilder().WithLayout((12, [])).Build();

        var places = new PlaceBuilder().With(Names.Place.Wells, PlaceAttributes.TownWithCathedral, tiles[2])
                                       .With(Names.Place.Coventry, PlaceAttributes.City, tiles[1])
                                       .Build();

        var roads = new RoadNetworkBuilder(tiles, places).BuildRoad(1, 2).BuildRoad(2, 5).BuildRoad(2, Names.Place.Coventry, 7).BuildRoad(7, 12).Build();

        var board = new Board(tiles, places, roads);
        var start = board.GetTile(startingTile);
        var player1 = new Faction();
        var player2 = new Faction();
        board.GetPlace(Names.Place.Coventry).GrantTo(player1);

        var destinations = board.PossibleDestinations(player2, start, 1, new ClassicMovementRules());
        var asString = AsString(destinations);
        Assert.That(asString, Is.EqualTo(expectedDestinations), asString);
    }

    private static string AsString(IEnumerable<(Tile destination, int distanceLeft)> destinations)
    {
        return destinations.Select(d => $"{d.destination.Id}({d.distanceLeft})").ToCommaSeparatedList();
    }
}
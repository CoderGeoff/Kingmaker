﻿using Kingmaker.Engine.Rules;

namespace Kingmaker.Engine.Board;

public class Tiles
{
    private readonly Tile[] _tiles;

    public Tiles(Tile[] tiles)
    {
        _tiles = tiles;
    }

    public Tile this[int i] => _tiles[i];

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start, int maximumDistance, ICrossCountryMovementRule rules)
    {
        if (maximumDistance <= 0) return [];

        var result = new Dictionary<Tile, int>();
        var destinations = rules.NextTileCrossCrossCountry(start, maximumDistance).ToList();
        while (destinations.Any())
        {
            var destination = destinations.First();
            destinations.RemoveAt(0);

            // don't travel to where we started
            if (destination.tile == start)
                continue;

            // don't travel where we've already been
            if (!result.TryAdd(destination.tile, destination.distanceLeft))
                continue;

            destinations.AddRange(rules.NextTileCrossCrossCountry(destination.tile, destination.distanceLeft));
        }

        return result.Select(entry => (entry.Key, entry.Value));
    }
}
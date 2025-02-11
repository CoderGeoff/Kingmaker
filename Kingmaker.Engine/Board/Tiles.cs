using Kingmaker.Engine.Rules;

namespace Kingmaker.Engine.Board;

public class Tiles
{
    private readonly Tile[] _tiles;

    public Tiles(Tile[] tiles)
    {
        _tiles = tiles;
    }

    public Tile this[int i] => _tiles[i];

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start, int maximumDistance, IMoveCrossCountryRules rules)
    {
        return maximumDistance <= 0 ? [] : TravelCrossCountry(start, maximumDistance, rules);
    }

    private IEnumerable<(Tile destination, int distanceLeft)> TravelCrossCountry(Tile start, int maximumDistance, IMoveCrossCountryRules rules)
    {
        var result = new Dictionary<Tile, int>();
        var destinations = rules.MoveOne(start, maximumDistance).ToList();
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

            destinations.AddRange(rules.MoveOne(destination.tile, destination.distanceLeft));
        }

        return result.Select(entry => (entry.Key, entry.Value));
    }
}
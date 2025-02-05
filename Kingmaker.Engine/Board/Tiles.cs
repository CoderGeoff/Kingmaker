namespace Kingmaker.Engine.Board;

public class Tiles
{
    private readonly Tile[] _tiles;

    public Tiles(Tile[] tiles)
    {
        _tiles = tiles;
    }

    public Tile this[int i] => _tiles[i];

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start, int maximumDistance)
    {
        return maximumDistance <= 0 ? [] : TravelCrossCountry(start, maximumDistance);
    }

    private IEnumerable<(Tile destination, int distanceLeft)> TravelCrossCountry(Tile start, int maximumDistance)
    {
        var result = new Dictionary<Tile, int>();
        var destinations = start.AdjacentTiles.Select(tile => (tile, distanceLeft: maximumDistance - 1)).ToList();
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

            // don't travel further than the maximum distance
            var distanceLeft = destination.distanceLeft - 1;
            if (distanceLeft < 0)
                continue;
            destinations.AddRange(destination.tile.AdjacentTiles.Select(tile => (tile, distanceLeft)));
        }

        return result.Select(entry => (entry.Key, entry.Value));
    }

}
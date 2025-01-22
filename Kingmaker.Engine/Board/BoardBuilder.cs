using System.Linq;

namespace Kingmaker.Engine.Board;

public class BoardBuilder
{
    private readonly Dictionary<int, Tile> _tiles = new();
    private readonly List<(int, int[])> _adjacentTiles = new();

    public BoardBuilder WithPlaces(PlaceAttributes placeAttributes, params (int tile, string placeNames)[] places)
    {
        return this;
    }

    public BoardBuilder WithTiles(params Tile[] tiles)
    {
        tiles.ToList().ForEach(t => _tiles.TryAdd(t.Id, t));
        return this;
    }

    public BoardBuilder WithLayout(params (int, int[])[] adjacentTiles)
    {
        _adjacentTiles.AddRange(adjacentTiles);
        return this;
    }

    public Board Build()
    {
        _adjacentTiles.ToList().ForEach(Set);
        return new Board(_tiles);

        void Set((int tile, int[] adjacentTiles) entry)
        {
            var thisTile = _tiles[entry.tile];
            var adjacentTiles = entry.adjacentTiles.Select(t => _tiles[t]).ToList();
            thisTile.IsAdjacentTo(adjacentTiles);
            adjacentTiles.ForEach(t => t.IsAdjacentTo([thisTile]));
        }
    }
}

public class PlaceAttributes
{
    public static PlaceAttributes CityWithCathedral { get; } = new(400, 200, false, true);
    public static PlaceAttributes City { get; } = new(400, 200, false, false);
    public static PlaceAttributes Castle { get; } = new(300, 100, false, false);
    public static PlaceAttributes RoyalCastle { get; } = new(300, 100, false, false);

    private PlaceAttributes(int capacity, int garrison, bool isOpen, bool hasCathedral)
    {
        
    }
}

public class Tile
{
    private readonly string[] _placeNames;
    private readonly List<Tile> _adjacentTiles = new();
    public Tile(int id, params string[] placeNames)
    {
        _placeNames = placeNames;
        Id = id;
    }
    public int Id { get; }

    public void IsAdjacentTo(IEnumerable<Tile> adjacentTiles)
    {
        var toBeAdded = adjacentTiles.Where(t => !_adjacentTiles.Contains(t));
        _adjacentTiles.AddRange(toBeAdded);
    }

    public IEnumerable<(Tile destination, int distanceLeft)> Travel(int maximumDistance)
    {
        var result = new Dictionary<Tile, int>();
        if (maximumDistance <= 0) return [];
        var destinations = _adjacentTiles.Select(tile => (tile, distanceLeft: maximumDistance - 1)).ToList();
        while (destinations.Any())
        {
            var destination = destinations.First();
            destinations.RemoveAt(0);
            if (!result.TryAdd(destination.tile, destination.distanceLeft)) continue;
            var distanceLeft = destination.distanceLeft - 1;
            if (distanceLeft < 0) continue;
            destinations.AddRange(destination.tile._adjacentTiles.Select(tile => (tile, distanceLeft)));
        }

        return result.Select(entry => (entry.Key, entry.Value)).OrderBy(entry => entry.Key.Id);
    }
}


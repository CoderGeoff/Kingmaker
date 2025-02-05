using System.Linq;

namespace Kingmaker.Engine.Board;

public class BoardBuilder
{
    private readonly Dictionary<int, Tile> _tiles = new();
    private readonly List<(int, int[])> _adjacentTiles = new();
    private readonly List<List<(int tile, string placeName)>> _roads = new();

    public BoardBuilder WithPlaces(PlaceAttributes placeAttributes, params (int tile, string placeNames)[] places)
    {
        return this;
    }

    public BoardBuilder WithRoad(params (int tile, string placeName)[] places)
    {
        _roads.Add(places.ToList());
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
        _adjacentTiles.ToList().ForEach(SetAdjacentTiles);
        return new Board(_tiles);

        void SetAdjacentTiles((int tile, int[] adjacentTiles) entry)
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

public class RoadSegment
{
    public RoadSegment(Tile tile)
    {
        _tile = tile;
    }

    private readonly Tile _tile;
    private RoadSegment? _red;
    private RoadSegment? _blue;

    public enum Direction { Red, Blue }

    public void Set(Direction direction, RoadSegment segment)
    {
        if (direction == Direction.Blue) _blue = segment;
        else _red = segment;
    }

    bool TryTravel(Direction direction, out RoadSegment segment)
    {
        var destination = direction switch
                          {
                          Direction.Red => _red,
                          Direction.Blue => _blue,
                          _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                          };
        segment = destination!;
        return destination != null;
    }
}

public class Tile
{
    private readonly string[] _placeNames;
    private readonly List<Tile> _adjacentTiles = new();
    private readonly List<RoadSegment> _roadSegments = new();

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
        return TravelCrossCountry(maximumDistance, result)
           .Concat(TravelByRoad())
              .DistinctBy(entry => entry.Key.Id)
              .OrderBy(entry => entry.Key.Id);
    }

    private IEnumerable<(Tile Key, int Value)> TravelByRoad()
    {
        return !IsOnRoad() ? [] : TravelByRoad2();

        IEnumerable<(Tile Key, int Value)> TravelByRoad2()
        {
            _
        }
    }

    private bool IsOnRoad()
    {
        return false;
    }

    private IEnumerable<(Tile Key, int Value)> TravelCrossCountry(int maximumDistance, Dictionary<Tile, int> result)
    {
        var destinations = _adjacentTiles.Select(tile => (tile, distanceLeft: maximumDistance - 1)).ToList();
        while (destinations.Any())
        {
            var destination = destinations.First();
            destinations.RemoveAt(0);
            
            // don't travel to where we started
            if (destination.tile == this) continue;

            // don't travel where we've already been
            if (!result.TryAdd(destination.tile, destination.distanceLeft)) continue; 

            // don't travel further than the maximum distance
            var distanceLeft = destination.distanceLeft - 1;
            if (distanceLeft < 0) continue;
            destinations.AddRange(destination.tile._adjacentTiles.Select(tile => (tile, distanceLeft)));
        }

        var valueTuples = result.Select(entry => (entry.Key, entry.Value));
        return valueTuples;
    }
}


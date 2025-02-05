namespace Kingmaker.Engine.Board;

public class Tile : CanBeOnARoad
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
        return TravelCrossCountry(maximumDistance, result)
              .Concat(TravelByRoad())
              .DistinctBy(entry => entry.Key.Id)
              .OrderBy(entry => entry.Key.Id);
    }

    private IEnumerable<(Tile Key, int Value)> TravelByRoad()
    {
        if (!IsOnRoad(out var nextRoadSegments))
            return [];

        var destinationsReached = nextRoadSegments.ToHashSet();
        var departurePoints = new Queue<CanBeOnARoad>(nextRoadSegments);
        while (departurePoints.TryDequeue(out var z))
        {
            if (!destinationsReached.Add(z)) continue;
            departurePoints.Enqueue(z);
        }
        return destinationsReached.OfType<Tile>().Select(z => (z, 0));
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
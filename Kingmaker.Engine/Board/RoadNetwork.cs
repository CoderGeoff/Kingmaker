namespace Kingmaker.Engine.Board;

public class RoadNetwork
{
    private readonly ILookup<Tile, (Place? mustPassThrough, Tile destination)> _roadSegments;
    public RoadNetwork(ILookup<Tile, (Place? mustPassThrough, Tile destination)> roadSegments)
    {
        _roadSegments = roadSegments;
    }

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start)
    {
        var result = new HashSet<Tile>(_roadSegments[start].Select(entry => entry.destination));
        var pending = new Queue<Tile>(result);
        while (pending.TryDequeue(out var next))
        {
            foreach (var possibleDestination in _roadSegments[next])
            {
                // don't travel back to where we started
                if (possibleDestination.destination == start) continue;
                // don't travel back to where we've passed through
                if (!result.Add(possibleDestination.destination)) continue;
                // note we should only look at must pass through here, when looking to add to pending
                pending.Enqueue(possibleDestination.destination);
            }
        }

        return result.Select(tile => (tile, 0));
    }
}
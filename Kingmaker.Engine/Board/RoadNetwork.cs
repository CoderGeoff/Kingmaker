using Kingmaker.Engine.Rules;

namespace Kingmaker.Engine.Board;

public class RoadNetwork
{
    private readonly ILookup<Tile, (Place? passesThrough, Tile destination)> _roadSegments;
    public RoadNetwork(ILookup<Tile, (Place? passesThrough, Tile destination)> roadSegments)
    {
        _roadSegments = roadSegments;
    }

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start, Faction faction, IMoveByRoadRules rules)
    {
        var (firstDestinations, cantReach) = rules.NextTileByRoad(_roadSegments[start], faction, 0);
        var pending = new Queue<(Tile destination, int hopCount)>(firstDestinations);
        var result = new HashSet<Tile>(pending.Select(segment => segment.destination));
        while (pending.TryDequeue(out var next))
        {
            var (nextDestinations, cantReach2) = rules.NextTileByRoad(_roadSegments[next.destination], faction, next.hopCount);
            foreach (var possibleDestination in nextDestinations)
            {
                // don't travel back to where we started
                if (possibleDestination.destination == start) continue;
                // don't travel back to where we've passed through
                if (!result.Add(possibleDestination.destination)) continue;
                // note we should only look at must pass through here, when looking to add to pending
                pending.Enqueue(possibleDestination);
            }
        }

        return result.Select(tile => (tile, 0));
    }
}
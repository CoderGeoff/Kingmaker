using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public class ClassicMovementRules : IMovementRules
{
    public IEnumerable<(Tile tile, int distanceLeft)> NextTileCrossCrossCountry(Tile start, int maximumDistance)
    {
        // don't travel further than the maximum distance
        if (maximumDistance <= 0) return [];
        var distanceLeft = maximumDistance - 1;
        return start.AdjacentTiles.Select(tile => (tile, distanceLeft));
    }

    public (IEnumerable<(Tile destination, int hopCount)> destinations, IEnumerable<(Tile destination, Place blockedBy)> unreachable) NextTileByRoad(IEnumerable<(Place? passesThrough, Tile destination)> roadSegments, Faction faction, int hopCount)
    {
        var destinations = roadSegments.Select(seg => (seg.destination, hopCount + 1));
        return (destinations, []);
    }
}

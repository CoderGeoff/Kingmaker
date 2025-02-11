using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public class ClassicRoadMovementRule : IRoadMovementRule
{
    public (IEnumerable<(Tile destination, int hopCount)> destinations, IEnumerable<(Tile destination, Place blockedBy)> unreachable) NextTileByRoad(IEnumerable<(Place? passesThrough, Tile destination)> roadSegments, Faction faction, int hopCount)
    {
        var destinations = roadSegments.Select(seg => (seg.destination, hopCount + 1));
        return (destinations, []);
    }
}
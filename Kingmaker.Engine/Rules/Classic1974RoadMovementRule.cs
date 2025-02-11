using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public class Classic1974RoadMovementRule : IRoadMovementRule
{
    public (IEnumerable<(Tile destination, int hopCount)> destinations, IEnumerable<(Tile destination, Place blockedBy)> unreachable) NextTileByRoad(IEnumerable<(Place? passesThrough, Tile destination)> roadSegments, Faction faction, int hopCount)
    {
        var destinations = roadSegments.Where(seg => !IsBlocked(seg.passesThrough))
                                       .Select(seg => (seg.destination, hopCount + 1));
        return (destinations, []);

        bool IsBlocked(Place? passesThrough)
        {
            return hopCount > 0 && passesThrough is not null && passesThrough.TryGetOwner(out var owner) && owner != faction;
        }
    }
}
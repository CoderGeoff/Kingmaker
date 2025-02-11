using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public interface IRoadMovementRule
{
    (IEnumerable<(Tile destination, int hopCount)> destinations, IEnumerable<(Tile destination, Place blockedBy)> unreachable) NextTileByRoad(IEnumerable<(Place? passesThrough, Tile destination)> roadSegments, Faction faction, int hopCount);
}
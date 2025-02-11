using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public class ClassicMovementRules : IMovementRules
{
    private readonly ClassicCrossCountryMovementRule _crossCountryMovementRule = new();
    private readonly Classic1974RoadMovementRule _roadMovementRule = new();

    public IEnumerable<(Tile tile, int distanceLeft)> NextTileCrossCrossCountry(Tile start, int maximumDistance)
    {
        return _crossCountryMovementRule.NextTileCrossCrossCountry(start, maximumDistance);
    }

    public (IEnumerable<(Tile destination, int hopCount)> destinations, IEnumerable<(Tile destination, Place blockedBy)> unreachable) NextTileByRoad(IEnumerable<(Place? passesThrough, Tile destination)> roadSegments, Faction faction, int hopCount)
    {
        return _roadMovementRule.NextTileByRoad(roadSegments, faction, hopCount);
    }
}

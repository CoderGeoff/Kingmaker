using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public class ClassicCrossCountryMovementRule : ICrossCountryMovementRule
{
    public IEnumerable<(Tile tile, int distanceLeft)> NextTileCrossCrossCountry(Tile start, int maximumDistance)
    {
        // don't travel further than the maximum distance
        if (maximumDistance <= 0)
            return [];
        var distanceLeft = maximumDistance - 1;
        return start.AdjacentTiles.Select(tile => (tile, distanceLeft));
    }
}
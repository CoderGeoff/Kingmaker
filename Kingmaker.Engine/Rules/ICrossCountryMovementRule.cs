using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public interface ICrossCountryMovementRule
{
    IEnumerable<(Tile tile, int distanceLeft)> NextTileCrossCrossCountry(Tile start, int distanceLeft);
}
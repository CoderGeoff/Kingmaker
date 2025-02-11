using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public interface IMoveCrossCountryRules
{
    IEnumerable<(Tile tile, int distanceLeft)> NextTileCrossCrossCountry(Tile start, int distanceLeft);
}
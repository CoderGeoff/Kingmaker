using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public interface IMoveCrossCountryRules
{
    IEnumerable<(Tile tile, int distanceLeft)> MoveOne(Tile start, int distanceLeft);
}
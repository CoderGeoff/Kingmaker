using Kingmaker.Engine.Board;

namespace Kingmaker.Engine.Rules;

public interface IMoveByRoadRules
{
    IEnumerable<(Place? mustPassThrough, Tile destination)> NextTileByRoad(Tile start, Faction faction, ILookup<Tile, (Place? mustPassThrough, Tile destination)> roadSegments);
}
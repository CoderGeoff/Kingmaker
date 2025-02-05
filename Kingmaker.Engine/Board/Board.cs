namespace Kingmaker.Engine.Board;

public class Board
{
    private readonly Tile[] _tiles;
    private readonly Dictionary<Names.Place, Place> _places;
    private readonly RoadNetwork _roads;

    public Board(Tile[] tiles, Dictionary<Names.Place, Place> places, RoadNetwork roads)
    {
        _tiles = tiles;
        _places = places;
        _roads = roads;
    }

    public Tile GetTile(int id)
    {
        return _tiles[id];
    }

    public IEnumerable<(Tile destination, int distanceLeft)> TravelFrom(Tile start, int distance)
    {
        var reachedCrossCountry = start.Travel(distance);
        var reachedByRoad = _roads.TravelFrom(start);
        var all = reachedCrossCountry.Concat(reachedByRoad).DistinctBy(entry => entry.destination).OrderBy(entry => entry.destination.Id);
        return all;
    }
}
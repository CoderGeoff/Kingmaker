namespace Kingmaker.Engine.Board;

public class Board
{
    private readonly Tiles _tiles;
    private readonly Dictionary<Names.Place, Place> _places;
    private readonly RoadNetwork _roads;

    public Board(Tiles tiles, Dictionary<Names.Place, Place> places, RoadNetwork roads)
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
        var reachedCrossCountry = _tiles.TravelFrom(start, distance);
        var reachedByRoad = _roads.TravelFrom(start);
        var all = reachedCrossCountry.Concat(reachedByRoad).DistinctBy(entry => entry.destination).OrderBy(entry => entry.destination.Id);
        return all;
    }
}
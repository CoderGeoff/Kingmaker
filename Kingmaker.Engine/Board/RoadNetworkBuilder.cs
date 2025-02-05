namespace Kingmaker.Engine.Board;

public class RoadNetworkBuilder
{
    private readonly Tiles _tiles;
    private readonly Dictionary<Names.Place, Place> _places;
    private readonly List<(Tile from, Place? via, Tile to)> _roadSegments = new();

    public RoadNetworkBuilder(Tiles tiles, Dictionary<Names.Place, Place> places)
    {
        _tiles = tiles;
        _places = places;
    }

    public RoadNetworkBuilder BuildRoad(int from, Names.Place via, int to)
    {
        _roadSegments.Add((_tiles[from], _places[via], _tiles[to]));
        return this;
    }

    public RoadNetworkBuilder BuildRoad(int from, int to)
    {
        _roadSegments.Add((_tiles[from], null, _tiles[to]));
        return this;
    }

    public RoadNetwork Build()
    {
        var returnSegments = _roadSegments.Select(seg => (from: seg.to, seg.via, to: seg.from));
        var lookup = _roadSegments.Concat(returnSegments).ToLookup(seg => seg.from, seg => (seg.via, seg.to));
        return new RoadNetwork(lookup);
    }

}
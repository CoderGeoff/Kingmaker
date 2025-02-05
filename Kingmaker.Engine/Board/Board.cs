namespace Kingmaker.Engine.Board;

public class Board
{
    private readonly Tile[] _tiles;
    private readonly Dictionary<Names.Place, Place> _places;

    public Board(Tile[] tiles, Dictionary<Names.Place, Place> places)
    {
        _tiles = tiles;
        _places = places;
    }

    public Tile GetTile(int id)
    {
        return _tiles[id];
    }
}
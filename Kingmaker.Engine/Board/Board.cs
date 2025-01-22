namespace Kingmaker.Engine.Board;

public class Board
{
    private readonly Dictionary<int, Tile> _tiles;

    public Board(Dictionary<int, Tile> tiles)
    {
        _tiles = tiles;
    }

    public Tile GetTile(int id)
    {
        return _tiles[id];
    }
}
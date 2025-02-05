namespace Kingmaker.Engine.Board;

public class Tile
{
    private readonly string[] _placeNames;
    private readonly List<Tile> _adjacentTiles = new();

    public Tile(int id, params string[] placeNames)
    {
        _placeNames = placeNames;
        Id = id;
    }
    public int Id { get; }

    public void IsAdjacentTo(IEnumerable<Tile> adjacentTiles)
    {
        var toBeAdded = adjacentTiles.Where(t => !_adjacentTiles.Contains(t));
        _adjacentTiles.AddRange(toBeAdded);
    }

    public IReadOnlyList<Tile> AdjacentTiles => _adjacentTiles;
}
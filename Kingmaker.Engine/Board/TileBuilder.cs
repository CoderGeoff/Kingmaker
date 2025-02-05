namespace Kingmaker.Engine.Board;

public class TileBuilder
{
    private readonly List<(int, int[])> _adjacentTiles = new();

    public TileBuilder WithLayout(params (int, int[])[] adjacentTiles)
    {
        _adjacentTiles.AddRange(adjacentTiles);
        return this;
    }

    public Tile[] Build()
    {
        var ensureSequenceIsNotEmpty = new [] { 0 };
        var highestId = _adjacentTiles.SelectMany(entry => new[] { entry.Item1 }.Concat(entry.Item2)).Concat(ensureSequenceIsNotEmpty).Max();
        var tiles = Enumerable.Range(0, highestId + 1).Select(id => new Tile(id)).ToArray();
        _adjacentTiles.ToList().ForEach(SetAdjacentTiles);
        return tiles;

        void SetAdjacentTiles((int tile, int[] adjacentTiles) entry)
        {
            var thisTile = tiles[entry.tile];
            var adjacentTiles = entry.adjacentTiles.Select(t => tiles[t]).ToList();
            thisTile.IsAdjacentTo(adjacentTiles);
            adjacentTiles.ForEach(t => t.IsAdjacentTo([thisTile]));
        }
    }
}
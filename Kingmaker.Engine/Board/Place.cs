using Kingmaker.Engine.Constants;

namespace Kingmaker.Engine.Board;

public class Place : IPlaceAttributes
{
    private readonly PlaceAttributes _attributes;
    private readonly Tile _tile;
    private Faction? _owner;

    public Place(Names.Place name, PlaceAttributes attributes, Tile tile)
    {
        _attributes = attributes;
        _tile = tile;
        Name = name;
    }

    public Names.Place Name { get; }
    public int Capacity => _attributes.Capacity;
    public int Garrison => _attributes.Garrison;
    public bool IsOpen => _attributes.IsOpen;
    public bool HasCathedral => _attributes.HasCathedral;

    public bool TryGrantTo(Faction faction)
    {
        if (IsOpen) return false;
        _owner = faction;
        return true;
    }

    public bool TryGetOwner(out Faction owner)
    {
        owner = _owner!;
        return _owner != null;
    }
}
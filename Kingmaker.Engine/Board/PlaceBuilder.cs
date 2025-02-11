using Kingmaker.Engine.Constants;

namespace Kingmaker.Engine.Board;

public class PlaceBuilder
{
    private readonly List<Place> _places = new();
    public PlaceBuilder With(Names.Place name, PlaceAttributes placeType, Tile tile)
    {
        _places.Add(new Place(name, placeType, tile));
        return this;
    }

    public Dictionary<Names.Place, Place> Build() => new (_places.ToDictionary(place => place.Name, place => place));
}
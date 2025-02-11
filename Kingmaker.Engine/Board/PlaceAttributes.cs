namespace Kingmaker.Engine.Board;

public class PlaceAttributes : IPlaceAttributes
{
    public string Description { get; }
    public int Capacity { get; }
    public int Garrison { get; }
    public bool IsOpen { get; }
    public bool HasCathedral { get; }
    public static PlaceAttributes None { get; } = new("<none>", 0, int.MaxValue, true, false);
    public static PlaceAttributes Town { get; } = new("town", 0, int.MaxValue, true, true);
    public static PlaceAttributes TownWithCathedral { get; } = new("town", 0, int.MaxValue, true, false);
    public static PlaceAttributes City { get; } = new("city", 400, 200, false, false);
    public static PlaceAttributes CityWithCathedral { get; } = new("city", 400, 200, false, true);
    public static PlaceAttributes Castle { get; } = new("castle", 300, 100, false, false);
    public static PlaceAttributes RoyalCastle { get; } = new("royal castle", 300, 100, false, false);

    private PlaceAttributes(string description, int capacity, int garrison, bool isOpen, bool hasCathedral)
    {
        Description = description;
        Capacity = capacity;
        Garrison = garrison;
        IsOpen = isOpen;
        HasCathedral = hasCathedral;
    }
}
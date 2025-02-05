namespace Kingmaker.Engine.Board;

public class PlaceAttributes : IPlaceAttributes
{
    public int Capacity { get; }
    public int Garrison { get; }
    public bool IsOpen { get; }
    public bool HasCathedral { get; }
    public static PlaceAttributes None { get; } = new(0, Int32.MaxValue, true, false);
    public static PlaceAttributes Town { get; } = new(0, Int32.MaxValue, true, true);
    public static PlaceAttributes TownWithCathedral { get; } = new(0, Int32.MaxValue, true, false);
    public static PlaceAttributes City { get; } = new(400, 200, false, false);
    public static PlaceAttributes CityWithCathedral { get; } = new(400, 200, false, true);
    public static PlaceAttributes Castle { get; } = new(300, 100, false, false);
    public static PlaceAttributes RoyalCastle { get; } = new(300, 100, false, false);

    private PlaceAttributes(int capacity, int garrison, bool isOpen, bool hasCathedral)
    {
        Capacity = capacity;
        Garrison = garrison;
        IsOpen = isOpen;
        HasCathedral = hasCathedral;
    }
}
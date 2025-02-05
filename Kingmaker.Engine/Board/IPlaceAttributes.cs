namespace Kingmaker.Engine.Board;

public interface IPlaceAttributes
{
    int Capacity { get; }
    int Garrison { get; }
    bool IsOpen { get; }
    bool HasCathedral { get; }
}
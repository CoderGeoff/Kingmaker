namespace Kingmaker.Engine.Board;

public abstract class CanBeOnARoad
{
    private readonly List<CanBeOnARoad> _roadSegments = new();
    public CanBeOnARoad BuildRoadTo(CanBeOnARoad segment)
    {
        _roadSegments.Add(segment);
        return segment;
    }

    public bool IsOnRoad(out IReadOnlyList<CanBeOnARoad> segments)
    {
        segments = _roadSegments;
        return segments.Any();
    }
}
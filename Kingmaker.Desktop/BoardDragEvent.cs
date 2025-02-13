namespace Kingmaker.Desktop;

public class BoardDragEvent
{
    private int _x;
    private int _y;
    public bool IsActive { get; private set; }

    public void Start(int x, int y)
    {
        _y = y;
        _x = x;
        IsActive = true;
    }

    public ScalingVector MoveTo(int x, int y)
    {
        var scalingVector = new ScalingVector(_x, _y, x, y);
        _x = x;
        _y = y;
        return scalingVector;
    }

    public ScalingVector Stop(int x, int y)
    {
        IsActive = false;
        return new ScalingVector(_x, _y, x, y);
    }

}
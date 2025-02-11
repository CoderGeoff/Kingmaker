using Kingmaker.Engine.Board;
using Kingmaker.Engine.Constants;

namespace Kingmaker.Engine;

public class Faction
{

}

public interface IMovablePiece
{
    public Faction Owner { get; } 
}

public class Stack: IMovablePiece
{
    public Faction Owner { get; }
}

public class Noble: IMovablePiece
{
    private Noble(Names.Noble name)
    {
        
    }

    public Faction Owner { get; }
    public static Noble Percy { get; } = new(Names.Noble.Percy);

}

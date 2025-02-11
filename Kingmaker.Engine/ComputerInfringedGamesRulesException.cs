namespace Kingmaker.Engine;

public class ComputerInfringedGamesRulesException : Exception
{
    public ComputerInfringedGamesRulesException(string message, Exception? innerException = null) : base(message, innerException) { }
}
namespace Tests;

public static class StringExtensions
{
    public static string ToCommaSeparatedList(this IEnumerable<string> strings)
    {
        return string.Join(", ", strings);
    }
}
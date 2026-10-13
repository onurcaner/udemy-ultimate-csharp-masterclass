namespace Section17_QuoteFinder.Helpers;

internal static class WordExtractor
{
    public static IEnumerable<string> GetAllWords(string text)
    {
        string[] punctuationMarks = [",", ".", "?", "!", ";", ":"];
        return punctuationMarks.Aggregate(
            text.Split(' ').AsEnumerable(),
            (query, punctuationMark) => query.Select(word => word.Replace(punctuationMark, string.Empty))
        );
    }
}
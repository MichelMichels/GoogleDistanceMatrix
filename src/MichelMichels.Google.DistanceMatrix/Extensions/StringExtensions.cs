namespace MichelMichels.Google.DistanceMatrix.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}

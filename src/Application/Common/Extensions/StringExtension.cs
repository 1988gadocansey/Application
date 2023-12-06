namespace ApplicantPortal.Application.Common.Extensions;

public static class StringExtensions
{
    public static string? TruncateLongString(this string? str, int maxLength)
    {
        return string.IsNullOrEmpty(str) ? str : str[..Math.Min(str.Length, maxLength)];
    }
}

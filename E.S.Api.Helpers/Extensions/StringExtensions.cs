namespace E.S.Api.Helpers.Extensions;

public static class StringExtensions
{
    public static string ToFirstLetterUpper(this string value) => $"{value[0].ToString().ToUpper()}{value[1..]}";

    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
    
    public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrEmpty(value);
}
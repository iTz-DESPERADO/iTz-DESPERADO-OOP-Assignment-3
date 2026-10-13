using System.Text.RegularExpressions;

namespace Collections.Validation;

public static class StringValidationExtensions
{
    private static readonly Regex EgyptianPhoneRegex = new(
        @"\A(?:0|\+20)1[0125][0-9]{8}\z",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex EgyptianNationalIdRegex = new(
        @"\A[23][0-9]{13}\z",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static bool IsValidEgyptianPhone(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && EgyptianPhoneRegex.IsMatch(value);
    }

    public static bool IsValidEgyptianNationalId(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && EgyptianNationalIdRegex.IsMatch(value);
    }
}

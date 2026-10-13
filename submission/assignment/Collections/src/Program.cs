using Collections.Validation;

var passed = 0;
var total = 0;

CheckPhone("01012345678", expected: true);
CheckPhone("+201512345678", expected: true);
CheckPhone("01312345678", expected: false);
CheckPhone("0101234567", expected: false);
CheckPhone("0101234567a", expected: false);

CheckNationalId("29901011234567", expected: true);
CheckNationalId("19901011234567", expected: false);
CheckNationalId("2990101123456", expected: false);

CheckPhone(null, expected: false);
CheckPhone("", expected: false);
CheckPhone("   ", expected: false);
CheckNationalId(null, expected: false);
CheckNationalId("", expected: false);
CheckNationalId("   ", expected: false);

Console.WriteLine($"\nResults: {passed}/{total} tests passed.");
Environment.ExitCode = passed == total ? 0 : 1;

void CheckPhone(string? input, bool expected)
{
    Check(nameof(StringValidationExtensions.IsValidEgyptianPhone), input, expected,
        input.IsValidEgyptianPhone());
}

void CheckNationalId(string? input, bool expected)
{
    Check(nameof(StringValidationExtensions.IsValidEgyptianNationalId), input, expected,
        input.IsValidEgyptianNationalId());
}

void Check(string method, string? input, bool expected, bool actual)
{
    total++;
    var success = actual == expected;
    if (success)
        passed++;

    var displayInput = input is null ? "<null>" : $"\"{input}\"";
    Console.WriteLine($"{(success ? "PASS" : "FAIL")} | {method} | {displayInput} | Expected: {expected} | Actual: {actual}");
}

namespace UnitConverter.Models;

public static class ConversionTypes
{
    public const string MilesToKilometers = "MilesToKilometers";
    public const string MilesToKilometersForTest = "Miles to Kilometers";
    public const string KilometersToMiles = "KilometersToMiles";
    public const string FahrenheitToCelsius = "FahrenheitToCelsius";
    public const string CelsiusToFahrenheit = "CelsiusToFahrenheit";
    public const string PoundsToKilograms = "PoundsToKilograms";
    public const string KilogramsToPounds = "KilogramsToPounds";
    public const string MegabytesToGigabytes = "MegabytesToGigabytes";
    public const string GigabytesToMegabytes = "GigabytesToMegabytes";

    public static readonly IReadOnlyDictionary<string, string> All =
        new Dictionary<string, string>
        {
            [MilesToKilometers] = "Miles To Kilometers",
            [KilometersToMiles] = "Kilometers To Miles",
            [FahrenheitToCelsius] = "Fahrenheit To Celsius",
            [CelsiusToFahrenheit] = "Celsius To Fahrenheit",
            [PoundsToKilograms] = "Pounds To Kilograms",
            [KilogramsToPounds] = "Kilograms To Pounds",
            [MegabytesToGigabytes] = "Megabytes To Gigabytes",
            [GigabytesToMegabytes] = "Gigabytes To Megabytes"
        };

}

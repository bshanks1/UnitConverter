using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    public string Output { get; set; }
    private readonly IConversionService conversionService;

    public QuickConversions(IConversionService conversionService)
    {
        this.conversionService = conversionService;
    }
    public void OnGetNormal()
    {

    }

    public IActionResult OnGetMilesToKilometers(string input)
    {
        PerformConversion(input, ConversionTypes.MilesToKilometers);
        return Page();
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        PerformConversion(input, ConversionTypes.KilometersToMiles);
        return Page();
    }

    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        PerformConversion(input, ConversionTypes.FahrenheitToCelsius);
        return Page();
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        PerformConversion(input, ConversionTypes.CelsiusToFahrenheit);
        return Page();
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        PerformConversion(input, ConversionTypes.PoundsToKilograms);
        return Page();
    }

    public IActionResult OnGetKilogramsToPounds(string input)
    {
        PerformConversion(input, ConversionTypes.KilogramsToPounds);
        return Page();
    }

    public IActionResult OnGetMegabytesToGigabytes(string input)
    {
        PerformConversion(input, ConversionTypes.MegabytesToGigabytes);
        return Page();
    }

    public IActionResult OnGetGigabytesToMegabytes(string input)
    {
        PerformConversion(input, ConversionTypes.GigabytesToMegabytes);
        return Page();
    }

    private void PerformConversion(string input, string conversionType)
    {
        decimal inputDecimal = 0;

        try
        {
            inputDecimal = Convert.ToDecimal(input);
            Output = conversionService.Convert(inputDecimal, conversionType).ToString();

        }
        catch (Exception e)
        {
            ViewData["Error Message"] = "Invalid input, please try again with a valid number";
        }
    }

    public IEnumerable<SelectListItem> PoundOptions =>
    [
        new("1 pound", "1"),
        new("5 pounds", "5"),
        new("10 pounds", "10"),
        new("25 pounds", "25"),
        new("50 pounds", "50")
    ];
}

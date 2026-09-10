using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = String.Empty;
    public string Output { get; set; } = String.Empty;

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = String.Empty;
    private double inputDouble = 0.0;

    public void OnGet()
    {
        ViewData.Add("ConversionType", ConversionType);
        ViewData["Title"] = "Conversions";

        try
        {
            inputDouble = Convert.ToDouble(Input);
        }

        catch (FormatException)
        {
            ViewData["ErrorMessage"] = "Input Needs to be a valid number.";
        }

        double outputDouble = 0.0;

        switch (ConversionType)
        {
            case "MilesToKilometers":
                UnitOf.Length unitMileKilo= new UnitOf.Length().FromMiles(inputDouble);
                outputDouble = unitMileKilo.ToKilometers();
                break;

            case "KilometersToMiles":
                UnitOf.Length unitKiloMile = new UnitOf.Length().FromKilometers(inputDouble);
                outputDouble = unitKiloMile.ToMiles();
                break;

            case "FahrenheitToCelsius":
                UnitOf.Temperature unitFheitCels = new UnitOf.Temperature().FromFahrenheit(inputDouble);
                outputDouble = unitFheitCels.ToCelsius();
                break;

            case "CelsiusToFahrenheit":
                UnitOf.Temperature unitCelsFheit = new UnitOf.Temperature().FromCelsius(inputDouble);
                outputDouble = unitCelsFheit.ToFahrenheit();
                break;

            case "PoundsToKilograms":
                UnitOf.Mass unitPoundKilo = new UnitOf.Mass().FromPounds(inputDouble);
                outputDouble = unitPoundKilo.ToKilograms();
                break;

            case "KilogramsToPounds":
                UnitOf.Mass unitKiloPound = new UnitOf.Mass().FromKilograms(inputDouble);
                outputDouble = unitKiloPound.ToPounds();
                break;

            case "LitersToPints":
                UnitOf.Volume unitLiterPint = new UnitOf.Volume().FromLiters(inputDouble);
                outputDouble = unitLiterPint.ToPintsUS();
                break;

            case "PintsToLiters":
                UnitOf.Volume unitPintLiter = new UnitOf.Volume().FromPintsUS(inputDouble);
                outputDouble = unitPintLiter.ToLiters();
                break;

            default:
                ViewData["ErrorMessage"] = "Conversion type not supported, please choose a supported conversion.";
                break;
        }

        String outputString = outputDouble.ToString();
    }
}

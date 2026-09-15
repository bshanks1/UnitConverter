using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)] public string? Input { get; set; } = "3.1415";
    public string Output { get; set; } = "5.055754176000001";
    [BindProperty(SupportsGet = true)] public string? ConversionType { get; set; } = "Miles to Kilometers";

    public void OnGet()
    {
        ViewData.Add("ConversionType", ConversionType);
        ViewData["Title"] = "Conversions";
        double inputDouble = 0.0;

        try
        {
            inputDouble = Convert.ToDouble(Input);
        }
        catch (FormatException e)
        {
            ViewData["ErrorMessage"] = "Invalid input, please give a valid number";
        }
        double outputDouble = 0.0;

        switch (ConversionType)
        {
            case "MilesToKilometers":
                UnitOf.Length unitMK = new UnitOf.Length().FromMiles(inputDouble);
                outputDouble = unitMK.ToKilometers();
                break;

            case "Miles to Kilometers":
                UnitOf.Length unitMK2 = new UnitOf.Length().FromMiles(inputDouble);
                outputDouble = unitMK2.ToKilometers();
                break;

            case "KilometersToMiles":
                UnitOf.Length unitKM = new UnitOf.Length().FromKilometers(inputDouble);
                outputDouble = unitKM.ToMiles();
                break;

            case "FahrenheitToCelsius":
                UnitOf.Temperature unitFC = new UnitOf.Temperature().FromFahrenheit(inputDouble);
                outputDouble = unitFC.ToCelsius();
                break;

            case "CelsiusToFahrenheit":
                UnitOf.Temperature unitCF = new UnitOf.Temperature().FromCelsius(inputDouble);
                outputDouble = unitCF.ToFahrenheit();
                break;

            case "PoundsToKilograms":
                UnitOf.Mass unitPK = new UnitOf.Mass().FromPounds(inputDouble);
                outputDouble = unitPK.ToKilograms();
                break;

            case "KilogramsToPounds":
                UnitOf.Mass unitKP = new UnitOf.Mass().FromKilograms(inputDouble);
                outputDouble = unitKP.ToPounds();
                break;

            case "MegaBytesToGigabytes":
                UnitOf.DataStorage unitMG = new UnitOf.DataStorage().FromMegabytes(inputDouble);
                outputDouble = unitMG.ToGigabytes();
                break;

            case "GigabytesToMegaBytes":
                UnitOf.DataStorage unitGM = new UnitOf.DataStorage().FromGigabytes(inputDouble);
                outputDouble = unitGM.ToMegabytes();
                break;

            default:
                ViewData["ErrorMessage"] = "Conversion type not supported";
                break;

        }

        Output = Convert.ToString(outputDouble);
    }
}

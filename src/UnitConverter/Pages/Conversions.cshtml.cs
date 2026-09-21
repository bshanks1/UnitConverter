using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)] public ConversionModel Conversion { get; set; } = new ConversionModel();

    [BindProperty(SupportsGet = true)] public string ConversionType { get; set; }

    [BindProperty(SupportsGet = true)] public string Input { get; set; }

    public string Output { get; set; }


    public void OnGet()
    {
        ViewData["Title"] = "Conversions";
        double inputDouble = 0.0;

        if (ConversionType != null && Input != null)
        {
            Conversion.ConversionType = ConversionType;
            Conversion.Input = Input;
        }

        if (Conversion.ConversionType == null && Conversion.Input == null)
        {
            Conversion.ConversionType = ConversionTypes.MilesToKilometersForTest;
            Conversion.Input = "3.1415";
            Input = "3.1415";
        }

        ViewData.Add("ConversionType", Conversion.ConversionType);

        try
        {
            inputDouble = Convert.ToDouble(Conversion.Input);
        }
        catch (FormatException e)
        {
            ViewData["ErrorMessage"] = "Invalid input, please give a valid number";
        }
        double outputDouble = 0.0;

        switch (Conversion.ConversionType)
        {
            case ConversionTypes.MilesToKilometers:
                UnitOf.Length unitMK = new UnitOf.Length().FromMiles(inputDouble);
                outputDouble = unitMK.ToKilometers();
                break;

            case ConversionTypes.MilesToKilometersForTest:
                UnitOf.Length unitMKT= new UnitOf.Length().FromMiles(inputDouble);
                outputDouble = unitMKT.ToKilometers();
                break;

            case ConversionTypes.KilometersToMiles:
                UnitOf.Length unitKM = new UnitOf.Length().FromKilometers(inputDouble);
                outputDouble = unitKM.ToMiles();
                break;

            case ConversionTypes.FahrenheitToCelsius:
                UnitOf.Temperature unitFC = new UnitOf.Temperature().FromFahrenheit(inputDouble);
                outputDouble = unitFC.ToCelsius();
                break;

            case ConversionTypes.CelsiusToFahrenheit:
                UnitOf.Temperature unitCF = new UnitOf.Temperature().FromCelsius(inputDouble);
                outputDouble = unitCF.ToFahrenheit();
                break;

            case ConversionTypes.PoundsToKilograms:
                UnitOf.Mass unitPK = new UnitOf.Mass().FromPounds(inputDouble);
                outputDouble = unitPK.ToKilograms();
                break;

            case ConversionTypes.KilogramsToPounds:
                UnitOf.Mass unitKP = new UnitOf.Mass().FromKilograms(inputDouble);
                outputDouble = unitKP.ToPounds();
                break;

            case ConversionTypes.MegabytesToGigabytes:
                UnitOf.DataStorage unitMG = new UnitOf.DataStorage().FromMegabytes(inputDouble);
                outputDouble = unitMG.ToGigabytes();
                break;

            case ConversionTypes.GigabytesToMegabytes:
                UnitOf.DataStorage unitGM = new UnitOf.DataStorage().FromGigabytes(inputDouble);
                outputDouble = unitGM.ToMegabytes();
                break;

            default:
                ViewData["ErrorMessage"] = "Conversion type not supported";
                break;

        }

        Conversion.Output = Convert.ToString(outputDouble);
        Output = Convert.ToString(outputDouble);
    }

}

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
    private double inputDouble;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData.Add("ConversionType", "Miles to Kilometers");
        ViewData["Title"] = "Conversions";

        try
        {
            inputDouble = Convert.ToDouble(Input);
        }

        catch (Exception e)
        {
            ViewData["ErrorMessage"] = "Input Needs to be a valid number.";
        }

        UnitOf.Length unit = new UnitOf.Length().FromMiles(inputDouble);
        double inputInKilometers = unit.ToKilometers();

        Output = Convert.ToString(inputInKilometers);
    }
}

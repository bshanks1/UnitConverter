using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = String.Empty;
    public string Output { get; set; } = String.Empty;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData.Add("ConversionType", "Miles to Kilometers");
        ViewData["Title"] = "Conversions";
        double inputDouble = Convert.ToDouble(Input);

        UnitOf.Length unit = new UnitOf.Length().FromMiles(inputDouble);
        double inputInKilometers = unit.ToKilometers();

        Output = Convert.ToString(inputInKilometers);
    }
}

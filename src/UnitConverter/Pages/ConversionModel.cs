using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionModel : PageModel
{
    public string ConversionType { get; set; }
    public string Input { get; set; }
    public string Output { get; set; }

    public ConversionModel()
    {
        ConversionType = "Miles to Kilometers";
        Input = "3.1415";
        Output = String.Empty;
    }
}

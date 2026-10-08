using Microsoft.VisualBasic;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class UnitOfConversionService : IConversionService
{
    public decimal Convert(decimal value, string conversionType)
    {
        double output = decimal.ToDouble(value);

        switch (conversionType)
        {

            case ConversionTypes.MilesToKilometers:
                UnitOf.Length unitMK = new UnitOf.Length().FromMiles(output);
                output = unitMK.ToKilometers();
                break;
            /*
            case ConversionTypes.MilesToKilometersForTest:
                UnitOf.Length unitMKT = new UnitOf.Length().FromMiles(output);
                output = unitMKT.ToKilometers();
                break;
                */

            case ConversionTypes.KilometersToMiles:
                UnitOf.Length unitKM = new UnitOf.Length().FromKilometers(output);
                output = unitKM.ToMiles();
                break;

            case ConversionTypes.FahrenheitToCelsius:
                UnitOf.Temperature unitFC = new UnitOf.Temperature().FromFahrenheit(output);
                output = unitFC.ToCelsius();
                break;

            case ConversionTypes.CelsiusToFahrenheit:
                UnitOf.Temperature unitCF = new UnitOf.Temperature().FromCelsius(output);
                output = unitCF.ToFahrenheit();
                break;

            case ConversionTypes.PoundsToKilograms:
                UnitOf.Mass unitPK = new UnitOf.Mass().FromPounds(output);
                output = unitPK.ToKilograms();
                break;

            case ConversionTypes.KilogramsToPounds:
                UnitOf.Mass unitKP = new UnitOf.Mass().FromKilograms(output);
                output = unitKP.ToPounds();
                break;

            case ConversionTypes.MegabytesToGigabytes:
                UnitOf.DataStorage unitMG = new UnitOf.DataStorage().FromMegabytes(output);
                output = unitMG.ToGigabytes();
                break;

            case ConversionTypes.GigabytesToMegabytes:
                UnitOf.DataStorage unitGM = new UnitOf.DataStorage().FromGigabytes(output);
                output = unitGM.ToMegabytes();
                break;

            default:
                output = 0;
                break;
        }

        return (decimal) output;
    }
}

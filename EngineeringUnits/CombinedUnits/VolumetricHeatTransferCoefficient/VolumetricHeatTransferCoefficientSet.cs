using EngineeringUnits.Units;
using System.Diagnostics.CodeAnalysis;

namespace EngineeringUnits;

//This class is auto-generated, changes to the file will be overwritten!
public partial class VolumetricHeatTransferCoefficient
{

    /// <summary>
    /// Get VolumetricHeatTransferCoefficient from SI.
    /// </summary>
    /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
    [return: NotNullIfNotNull(nameof(SI))]
    public static VolumetricHeatTransferCoefficient? FromSI(double? SI)
    {
        if (SI is null)
            return null;
        
        return new VolumetricHeatTransferCoefficient((double)SI, VolumetricHeatTransferCoefficientUnit.SI);
    }
    /// <summary>
    /// Get VolumetricHeatTransferCoefficient from WattPerCubicMeterKelvin.
    /// </summary>
    /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
    [return: NotNullIfNotNull(nameof(WattPerCubicMeterKelvin))]
    public static VolumetricHeatTransferCoefficient? FromWattPerCubicMeterKelvin(double? WattPerCubicMeterKelvin)
    {
        if (WattPerCubicMeterKelvin is null)
            return null;
        
        return new VolumetricHeatTransferCoefficient((double)WattPerCubicMeterKelvin, VolumetricHeatTransferCoefficientUnit.WattPerCubicMeterKelvin);
    }

}
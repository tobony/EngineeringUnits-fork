﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EngineeringUnits
{


    public class MolarityUnit : Enumeration
    {

        public static readonly MolarityUnit SI = new MolarityUnit(AmountOfSubstanceUnit.Mole, VolumeUnit.CubicMeter);
        public static readonly MolarityUnit MolesPerCubicMeter = new MolarityUnit(AmountOfSubstanceUnit.Mole, VolumeUnit.CubicMeter);
        public static readonly MolarityUnit MolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Mole, VolumeUnit.Liter);
        public static readonly MolarityUnit NanomolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Nanomole, VolumeUnit.Liter);
        public static readonly MolarityUnit PicomolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Picomole, VolumeUnit.Liter);
        public static readonly MolarityUnit CentimolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Centimole, VolumeUnit.Liter);
        public static readonly MolarityUnit DecimolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Decimole, VolumeUnit.Liter);
        public static readonly MolarityUnit MicromolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Micromole, VolumeUnit.Liter);
        public static readonly MolarityUnit MillimolesPerLiter = new MolarityUnit(AmountOfSubstanceUnit.Millimole, VolumeUnit.Liter);



        public MolarityUnit(AmountOfSubstanceUnit amountOfSubstance, VolumeUnit volume, string NewSymbol = "Empty", decimal correction = 1)
        {
            Unit = amountOfSubstance.Unit / volume.Unit;
            SetCombined(correction);
            SetNewSymbol(NewSymbol, $"{amountOfSubstance}/{volume}");
        }       

    }




}
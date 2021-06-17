﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EngineeringUnits
{


    public class ForceUnit : Enumeration
    {
        public static ForceUnit SI = new ForceUnit(MassUnit.SI, LengthUnit.SI, DurationUnit.SI, "N");
        public static ForceUnit Newton = new ForceUnit(MassUnit.SI, LengthUnit.SI , DurationUnit.SI , "N");
        public static ForceUnit Micronewton = new ForceUnit(PreFix.micro, Newton);
        public static ForceUnit Millinewton = new ForceUnit(PreFix.milli, Newton);
        public static ForceUnit Decanewton = new ForceUnit(PreFix.deka, Newton);
        public static ForceUnit Kilonewton = new ForceUnit(PreFix.kilo, Newton);
        public static ForceUnit Meganewton = new ForceUnit(PreFix.mega, Newton);

        public static ForceUnit Dyn = new ForceUnit(MassUnit.Gram, LengthUnit.Centimeter, DurationUnit.SI, "dyn");
        public static ForceUnit TonneForce = new ForceUnit(MassUnit.Tonne, AccelerationUnit.StandardGravity);
        public static ForceUnit ShortTonForce = new ForceUnit(MassUnit.ShortTon, AccelerationUnit.StandardGravity , "tf (short)");
        public static ForceUnit PoundForce = new ForceUnit(MassUnit.Pound, AccelerationUnit.StandardGravity);
        public static ForceUnit KilogramForce = new ForceUnit(MassUnit.Kilogram, AccelerationUnit.StandardGravity);
        public static ForceUnit OunceForce = new ForceUnit(MassUnit.Ounce, AccelerationUnit.StandardGravity);
        public static ForceUnit KiloPond = new ForceUnit(MassUnit.Kilogram, AccelerationUnit.StandardGravity, "kp");
        public static ForceUnit KilopoundForce = new ForceUnit(MassUnit.Kilopound, AccelerationUnit.StandardGravity, "kipf");
        public static ForceUnit Poundal = new ForceUnit(MassUnit.SI, LengthUnit.SI, DurationUnit.SI, "pdl", 0.138254954376m);

        public ForceUnit(MassUnit mass, LengthUnit Length, DurationUnit duration, string NewSymbol = "", decimal correction = 1)
        {

            Name = "Force";

            //kg*m2*s-2
            Unit = (mass.Unit * Length.Unit) / (duration.Unit * duration.Unit);

            if (NewSymbol != "")
            {
                Unit.Symbol = NewSymbol;
            }

            if (correction != 1)
            {
                Unit.Combined = new CombinedUnit("", 1, correction);
            }


        }

        public ForceUnit(MassUnit mass, AccelerationUnit acceleration, string NewSymbol = "", decimal correction = 1)
        {

            Name = "Force";

            Unit = mass.Unit * acceleration.Unit;

            if (NewSymbol != "")
            {
                Unit.Symbol = NewSymbol;
            }
            else
            {
                Unit.Symbol = $"{mass}f";
            }

            if (correction != 1)
            {
                Unit.Combined = new CombinedUnit("", 1, correction);
            }
        }

        public ForceUnit(PreFix SI, ForceUnit energyunit)
        {
            Unit = energyunit.Unit.Copy();


            if (Unit.Combined is null)
                Unit.Combined = new CombinedUnit("", 1, PrefixSISize(SI));
            else
                Unit.Combined.GlobalC *= PrefixSISize(SI);




            Unit.Symbol = PrefixSISymbol(SI) + Unit.Symbol;
        }

        public static IEnumerable<ForceUnit> List()
        {
            return new[] { Decanewton, Dyn, KilogramForce, Kilonewton, KiloPond, KilopoundForce, Meganewton, Micronewton, Millinewton, Newton, OunceForce, Poundal, PoundForce, ShortTonForce, TonneForce, };
        }





    }




}
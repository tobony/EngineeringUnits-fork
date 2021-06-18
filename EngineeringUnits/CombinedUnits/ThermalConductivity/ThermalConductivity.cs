﻿using Fractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringUnits
{
    public partial class ThermalConductivity : BaseUnit
    {

        public ThermalConductivity()
        {
            Name = "ThermalConductivity";
        }

        public ThermalConductivity(decimal value, ThermalConductivityUnit selectedUnit) : base(value, selectedUnit.Unit) { }
        public ThermalConductivity(double value, ThermalConductivityUnit selectedUnit) : base(value, selectedUnit.Unit) { }
        public ThermalConductivity(int value, ThermalConductivityUnit selectedUnit) : base(value, selectedUnit.Unit) { }


        public static ThermalConductivity From(double value, ThermalConductivityUnit unit) => new ThermalConductivity(value, unit);
        public double As(ThermalConductivityUnit ReturnInThisUnit) => (double)ToTheOutSide(ReturnInThisUnit.Unit);
        public ThermalConductivity ToUnit(ThermalConductivityUnit selectedUnit) => new ThermalConductivity(ToTheOutSide(selectedUnit.Unit), selectedUnit);


        public static implicit operator ThermalConductivity(UnknownUnit Unit)
        {
            ThermalConductivity local = new ThermalConductivity(0, ThermalConductivityUnit.SI);

            local.Transform(Unit);
            return local;
        }




    }
}
﻿using Fractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringUnits
{
    public partial class MolarMass : BaseUnit
    {

        public MolarMass()
        {
            Name = "MolarMass";
        }

        public MolarMass(decimal value, MolarMassUnit selectedUnit) : base(value, selectedUnit.Unit) { }
        public MolarMass(double value, MolarMassUnit selectedUnit) : base(value, selectedUnit.Unit) { }
        public MolarMass(int value, MolarMassUnit selectedUnit) : base(value, selectedUnit.Unit) { }


        public static MolarMass From(double value, MolarMassUnit unit) => new MolarMass(value, unit);
        public double As(MolarMassUnit ReturnInThisUnit) => (double)ToTheOutSide(ReturnInThisUnit.Unit);
        public MolarMass ToUnit(MolarMassUnit selectedUnit) => new MolarMass(ToTheOutSide(selectedUnit.Unit), selectedUnit);


        public static implicit operator MolarMass(UnknownUnit Unit)
        {
            MolarMass local = new MolarMass(0, MolarMassUnit.SI);

            local.Transform(Unit);
            return local;
        }




    }
}
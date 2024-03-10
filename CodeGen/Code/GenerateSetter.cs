﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeGen.Code;

internal class GenerateSetter
{

    public static void GenerateSetterClasses(string projectPath)
    {
        List<string> list = ListOfUnitsForDifferentGenerators.GetListOfCombinedUnits();
        //list.AddRange(ListOfUnitsForDifferentGenerators.GetListOfCombinedUnits());

        foreach (var item in list)
        {

            var sb = Setter(item);

            if (sb is null)
                continue;

            foreach (var i in item)
            {

                sb = sb.Replace("Variable", $"{item}");

            }

            var projectPathWithUnit = Path.Combine(projectPath, "CombinedUnits", item);

            File.WriteAllText(Path.Combine(projectPathWithUnit, $"{item}Set.cs"), sb.ToString());

        }

        foreach (var item in ListOfUnitsForDifferentGenerators.GetListOfBaseUnits())
        {

            var sb = Setter(item);

            if (sb is null)
                continue;

            foreach (var i in item)
            {

                sb = sb.Replace("Variable", $"{item}");

            }

            var projectPathWithUnit = Path.Combine(projectPath, "BaseUnits", item);

            File.WriteAllText(Path.Combine(projectPathWithUnit, $"{item}Set.cs"), sb.ToString());

        }
    }

    public static string Setter(string className)
    {

        var name = "EngineeringUnits.Units." + className + "Unit, EngineeringUnits";
        var t = Type.GetType(name);

        if (t is null)
        {
            return null;
        }

        var sb = new StringBuilder();

        _=sb.AppendLine(@"
using EngineeringUnits.Units;


namespace EngineeringUnits
{
    //This class is auto-generated, changes to the file will be overwritten!
    public partial class Variable
    {

 ");

        foreach (System.Reflection.FieldInfo i in t.GetFields())
        {

            _=sb.Append(@"
        /// <summary>
        ///     Get Variable from UnitEnum.
        /// </summary>
        /// <exception cref=""ArgumentException"">If value is NaN or Infinity.</exception>
        public static Variable FromUnitEnum(double? UnitEnum)
        {
            if (UnitEnum is null)
                return null;

            return new Variable((double)UnitEnum, VariableUnit.UnitEnum);
        }");

            sb = sb.Replace("UnitEnum", $"{i.Name}");
        }

        _=sb.AppendLine(@"
    }
}

");

        return sb.ToString();

    }
}

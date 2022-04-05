﻿using Fractions;
using Newtonsoft.Json;
using EngineeringUnits.Units;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace EngineeringUnits
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore, ItemTypeNameHandling = TypeNameHandling.All)]
    public record RawUnit
    {

        [JsonProperty(PropertyName = "S", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)][DefaultValue("")]
        public string Symbol { get; init; } 

        public Fraction A { get; init; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)][DefaultValue(0d)]
        public decimal B { get; init; }

        [JsonProperty(PropertyName = "C", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)][DefaultValue(1)]
        public int Count { get; init; } 
        public BaseunitType UnitType { get; init; }

        [JsonIgnore]
        public Fraction TotalConstant => Fraction.Pow(A, Count);

        [JsonIgnore]
        public bool IsSI => A == Fraction.One && B == 0;

        public RawUnit() {}



        public RawUnit CloneAndReverseCount()
        {
            return this with
            {
                Count = Count * -1,
                HashCode = 0,
            };

        }

        public RawUnit CloneWithNewCount(int newCount)
        {
            return this with
            {
                Count = newCount,
                HashCode = 0,
            };

        }


        private int HashCode;

        public override int GetHashCode()
        {

            if (HashCode == 0)
            {
                unchecked // Overflow is fine, just wrap
                {
                    HashCode = (int)2166136261;
                    HashCode = (HashCode * 16777619) ^ A.GetHashCode();
                    HashCode = (HashCode * 45476689) ^ B.GetHashCode();
                    HashCode = (HashCode * 16777619) ^ Count.GetHashCode();
                    HashCode = (HashCode * 16777619) ^ UnitType.GetHashCode();                  
                }
            }

            return HashCode;
        }
    }
}
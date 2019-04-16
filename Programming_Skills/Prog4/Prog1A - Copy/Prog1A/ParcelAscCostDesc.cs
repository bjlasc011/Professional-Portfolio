// By: D4823
// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018

// File: ParcelAscCostDesc
// This class is created from the base class Comparer. This class compares two Parcels by their type as a string in 
// ascending order, then compares their cost in descending order

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class ParcelAscCostDesc : Comparer<Parcel>
    {
        public override int Compare(Parcel x, Parcel y)
        {
            if (x == null)                      // only check if x is null once
                return (y == null) ? 0 : 1;     // check if y is null only if x is null ? null == null : (-1) * (-1)
            else { 
                int typeResult = x.GetType().ToString().CompareTo(y?.GetType().ToString()); //typeResult holds value from Comparing types. Don't call CompareTo() more than needed
                return (typeResult == 0) ? (-1) * x.CalcCost().CompareTo(y.CalcCost()) : typeResult;
            }
        }
    }
}

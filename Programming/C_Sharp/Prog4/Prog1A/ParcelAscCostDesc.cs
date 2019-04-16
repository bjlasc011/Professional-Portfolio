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
        // precondition:    two parcel objects
        // postcondition:   returns an int signifying the Parcels order when comparing by type name in ascending order,
        //                  then by cost in descending order. 0: (x == y), -1: (x > y), 1: (y > x).
        public override int Compare(Parcel x, Parcel y)
        {
            if (x == null && y == null)
                return 0;   // only check if x is null once

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            int typeResult = x.GetType().ToString().CompareTo(y.GetType().ToString());  // hold type comparison result
            return (typeResult == 0) ? (-1) * x.CompareTo(y) : typeResult;              // default compare to is CalcCost...


            /******************** ALTERNATIVE *************************/
            //int? typeResult = x?.GetType().ToString().CompareTo(y?.GetType().ToString());  // hold type comparison result

            //if (typeResult == null)
            //    return (y == null) ? 0 : -1;

            //return (typeResult == 0) ? (-1) * x.CompareTo(y) : (int)typeResult;

        }
    }
}

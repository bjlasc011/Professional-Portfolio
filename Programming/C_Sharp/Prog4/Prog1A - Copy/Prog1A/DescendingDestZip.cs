// By: D4823
// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018

// File: DescendingDestZip
// This class is created from the base class Comparer. This class compares two Parcels by their zip code
// and returns 0 if both objects are 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class DescendingDestZip : Comparer<Parcel>
    {
        // Precondition:  two Parcel references
        // Postcondition: returns an int signifying the Parcels order in relation to each other.
        //                0: (x == y), -1: (x > y), 1: (y > x.)
        public override int Compare(Parcel x, Parcel y)
        {
            if (x == null)          // only check if x is null once
            {
                return (y == null) ? 0 : 1;      // check if y is null only if x is null ? null == null : (-1) * (-1)
            }
            else return (-1) * x.DestinationAddress.Zip.CompareTo(y?.DestinationAddress.Zip);
            // x != null, we don't know about y, but CompareTo() handles null arguments
        }
    }
}

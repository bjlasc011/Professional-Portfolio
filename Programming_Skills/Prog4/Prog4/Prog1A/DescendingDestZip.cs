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
            if (x == null && y == null)
                return 0;

            if (x == null)
                return 1;

            if (y == null)
                return -1;

            // Bellow if statements are required for null address tests, for example:
            // new GroundPackage(null, null, 1.5, 5, 4, 3.52),
            // But the current parcel derived classes don't prevent null address references if we comment out lines  -  we see that
            // we cannot assume the Addresses within a Parcel instance can never be null. Without the code below we will get a 
            // null obj reference exception

            // Also the Ground package class wasn't acounting for a null address posibility >>> GroundPackage.cs line 43 in CalcCost(). 
            // so I added null address handling when calculating Zone distance and Cost. Without this a null address would crash the program.

            if (x.DestinationAddress == null && y.DestinationAddress == null)
                return 0;

            if (x.DestinationAddress == null)
                return 1;

            if (y.DestinationAddress == null)
                return -1;

            return (-1) * x.DestinationAddress.Zip.CompareTo(y.DestinationAddress.Zip);


            /******************** ALTERNATIVE *************************/
            //// Results in any Parcel that is null or any Parcel with a null DestinationAddress 
            //// being listed last in no particular order bc the zip is null either way.
            //int? result = (-1) * x?.DestinationAddress?.Zip.CompareTo(y?.DestinationAddress?.Zip);
            //return (result == null) ? (y == null) ? 0 : 1 : (int)result; // x was null => -1*-1, else => res
        }
    }
}

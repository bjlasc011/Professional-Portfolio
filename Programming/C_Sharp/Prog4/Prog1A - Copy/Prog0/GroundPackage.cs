/* D4823
 * Prog1A
 * 9/24/2018
 * CIS 200-01
 * Program Description: classes created to represent shipping objects exhibiting inheritence, polymorphism, and data validation.
 * 
 * File: GroundPackage.cs
 * 
 * The GroundPackage class has L*H*W & weight properties as well as an origin and destination address. It also has a zoneDistance property
 * that is used in csot calculations. A GroundPackage is a Package.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public class GroundPackage : Package
    {
        // Precondition:    Address obj as origin, Address obj as destination, length as positive double,
        //                  width as positive double, height as positive double, weight as positive double,
        // Postcondition:   The GroundPackage is created with the specified values for dimensions and 
        //                  origin address and destination address
        public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        {/* nothing needed */ }
        // Precondition:  None
        // Postcondition: the calculated absolute value of ZoneDistance is returned.
        public int ZoneDistance{ get => Math.Abs((OriginAddress.Zip/10000) - (DestinationAddress.Zip/10000));}

        private const decimal DIMENSION_MULTIPLIER = 0.20M; // Holds magic number to be multiplied against dimension
        private const decimal ZONE_DIST_MULTIPLIER = 0.05M; // Holds magic number to be multiplied against ZoneDistance
        // Precondition:  None
        // Postcondition: the calculated cost of the package has been returned
        public override decimal CalcCost() => DIMENSION_MULTIPLIER * ((decimal)Length + (decimal)Width + (decimal)Height) + ZONE_DIST_MULTIPLIER * (ZoneDistance + 1) * (decimal)Weight;
        // Precondition:  None
        // Postcondition: A String with the GroundPackage's data has been returned
        public override string ToString() => 
            $"**  GROUND PACKAGE  **" +
            $"\n{nameof(ZoneDistance),-12}{ZoneDistance,6}" +
            $"\n{base.ToString()}";
    }
}

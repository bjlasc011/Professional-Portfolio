/* D4823
 * Prog1A
 * 9/24/2018
 * CIS 200-01
 * Program Description: classes created to represent shipping objects exhibiting inheritence, polymorphism, and data validation.
 * 
 * File: AirPackage.cs
 * 
 * The AirPackage class has L*H*W & weight properties as well as an origin and destination address. It also has two additional funcs
 * that determine if they are heavy or large. A AirPackage is a Package.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public abstract class AirPackage : Package
    {
        // Precondition:    Address obj as origin, Address obj as destination, length as positive double,
        //                  width as positive double, height as positive double, weight as positive double,
        // Postcondition:   The AirPackage is created with the specified values for dimensions and 
        //                  origin address and destination address
        public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        { /* nothing needed */ }

        private const int IS_HEAVY_MIN_INCLUSIVE = 75;  // const to hold magic number of Heavy threshhold value
        private const int IS_LARGE_MIN_INCLUSIVE = 100; // const to hold magic number of Large threshhold value
        // Precondition:  None
        // Postcondition: A boolean has been returned anwsering the question, "Is this AirPackage Heavy?"
        public bool IsHeavy() => (Weight >= IS_HEAVY_MIN_INCLUSIVE) ? true : false;
        // Precondition:  None
        // Postcondition: A boolean has been returned anwsering the question, "Is this AirPackage Larg?"
        public bool IsLarge() => ((Length + Width + Height) >= IS_LARGE_MIN_INCLUSIVE) ? true : false;
        // Precondition:  None
        // Postcondition: A String with the AirPackage's data has been returned
        public override string ToString() => 
            $"{nameof(IsHeavy),-12}{IsHeavy(),6}" +
            $"\n{nameof(IsLarge),-12}{IsLarge(),6}" +
            $"\n{base.ToString()}";
    }
}

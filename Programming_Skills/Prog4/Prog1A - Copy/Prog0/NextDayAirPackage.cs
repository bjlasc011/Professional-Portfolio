/* D4823
 * Prog1A
 * 9/24/2018
 * CIS 200-01
 * Program Description: classes created to represent shipping objects exhibiting inheritence, polymorphism, and data validation.
 * 
 * File: NextDayAirPackage.cs
 * 
 * The NextDayAirPackage class has L*H*W & weight properties as well as an origin and destination address. It also has two additional funcs
 * that determine if they are heavy or large. Also has an double ExpressFee. A NextDayAirPackageAirPackage is a AirPackage .
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public class NextDayAirPackage : AirPackage
    {
        private const int MIN_FEE = 0;                      // const to hold minimum fee (exclusive)
        private const decimal DIMENSION_MULTIPLIER = 0.4M;  // const to hold Dimension multiplier in CalcCost()
        private const decimal WEIGHT_MULTIPLIER = 0.30M;    // const to hold Weight multiplier in CalcCost()
        private const decimal HEAVY_CHARGE = 0.25M;         // const to hold heavy up-charge multiplier in CalcCost()
        private const decimal LARGE_CHARGE = 0.25M;         // const to hold large up-charge multiplier in CalcCost()
        // Precondition:    Address obj as origin, Address obj as destination, length as positive double,
        //                  width as positive double, height as positive double, weight as positive double, expressFee as a positive decimal
        // Postcondition:   The NextDayAirPackage is created with the specified values for dimensions, expressFee, and 
        //                  origin address and destination address
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee) 
            : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        private decimal _expressFee;    // ExpressFee backing field
        public decimal ExpressFee
        {
            // Precondition:  None
            // Postcondition: The NextDayAirPackage's _expressFee has been returned
            get => _expressFee;
            // Precondition:  value > MIN_FEE of 0
            // Postcondition: The NextDayAirPackage's ExpressFee has been set to value
            private set
            {
                if (value > MIN_FEE) { _expressFee = value; }
                else { throw new ArgumentOutOfRangeException("Express Fee", value, $"Express Fee must be > {MIN_FEE}"); }
            }
        }
        // Precondition:  None
        // Postcondition: the calculated cost of the NextDayAirPackage has been returned
        public override decimal CalcCost()
        {
            decimal totalCost = DIMENSION_MULTIPLIER * ((decimal)Length + (decimal)Width + (decimal)Height) + (WEIGHT_MULTIPLIER * (decimal)Weight) + ExpressFee;
            if (IsHeavy())
                { totalCost += (HEAVY_CHARGE * (decimal)Weight);}
            if (IsLarge())
                { totalCost += (LARGE_CHARGE * ((decimal)Length + (decimal)Width + (decimal)Height)); }
            return totalCost;
        }
        // Precondition:  None
        // Postcondition: A String with the NextDayAirPackage's data has been returned
        public override string ToString() => 
            $"**  NEXT DAY AIR  **" +
            $"\n{nameof(ExpressFee),-12}{ExpressFee,6:C}" +
            $"\n{base.ToString()}";
    }
}

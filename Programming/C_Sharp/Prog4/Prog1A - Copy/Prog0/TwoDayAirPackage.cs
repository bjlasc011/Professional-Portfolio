/* D4823
 * Prog1A
 * 9/24/2018
 * CIS 200-01
 * Program Description: classes created to represent shipping objects exhibiting inheritence, polymorphism, and data validation.
 * 
 * File: TwoDayAirPackage.cs
 * 
 * The TwoDayAirPackage class has L*H*W & weight properties as well as an origin and destination address. It also hasa a Delivery type.
 * A TwoDayAirPackage is a AirPackage .
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public class TwoDayAirPackage : AirPackage
    {
        // Precondition:    Address obj as origin, Address obj as destination, length as positive double,
        //                  width as positive double, height as positive double, weight as positive double, deliveryType ofType enum Delivery
        // Postcondition:   The TwoDayAirPackage is created with the specified values for dimensions, DeliveryType, and 
        //                  origin address and destination address
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery deliveryType)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }
        private const decimal DIMENSION_MULTIPLIER = 0.25M; // const to hold the dimension multiplier used in CalcCost()
        private const decimal SAVER_MULTIPLIER = 0.9M;      // const to hold the saver multiplier used in CalcCost()
        public enum Delivery { Early, Saver }   // enum to hold the DeliveryType of the TwoDayAirPackage

        private Delivery _deliveryType;         // backing field of DeliveryType
        public Delivery DeliveryType
        {
            // Precondition:  None
            // Postcondition: The TwoDayAirPackage _deliveryType has been returned
            get => _deliveryType;
            // Precondition:  value is of type (Delivery.Early || Delivery.Saver)
            // Postcondition: The TwoDayAirPackage's DeliveryType is set to value
            set
            {
                if ( value == Delivery.Early || value == Delivery.Saver )
                    { _deliveryType = value; }
                else
                    { throw new ArgumentOutOfRangeException("Delivery Type", value, "Delivery Type must be Early or Saver"); }
            }
        }
        // Precondition:  None
        // Postcondition: the calculated cost of the TwoDayAirPackage has been returned
        public override decimal CalcCost() 
        {
            decimal cost = DIMENSION_MULTIPLIER * ((decimal)Length + (decimal)Width + (decimal)Height) + (DIMENSION_MULTIPLIER * (decimal)Weight);
            if(DeliveryType == Delivery.Saver)
                { cost *= SAVER_MULTIPLIER; }
            return cost;
        }
        // Precondition:  None
        // Postcondition: A String with the NextDayAirPackage's data has been returned
        public override string ToString() => 
            $"**  TWO DAY AIR PACKAGE  **" +
            $"\n{nameof(DeliveryType),-12}{DeliveryType,6}" +
            $"\n{base.ToString()}";
    }
}

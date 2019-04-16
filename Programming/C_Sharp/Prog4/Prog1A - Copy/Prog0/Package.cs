/* D4823
 * Prog1A
 * 9/24/2018
 * CIS 200-01
 * Program Description: classes created to represent shipping objects exhibiting inheritence, polymorphism, and data validation.
 * 
 * File: Package.cs
 * 
 * The Package class has L*H*W & weight properties as well as an origin and destination address. It is a parcel.
 */
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public abstract class Package : Parcel
    {
        // Precondition:    Address obj as origin, Address obj as destination, length as positive double,
        //                  width as positive double, height as positive double, weight as positive double,
        // Postcondition:   The Package is created with the specified values for
        //                  origin address and destination address
        public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight) :
            base(originAddress, destAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }
        private const double MIN_DIMENSION = 0; // const representing minimum dimension (exclusive)
        private double 
            _length,    // package dimension for length
            _width,     // package dimension for width
            _height,    // package dimension for height
            _weight;    // package dimension for Weight
        // Precondition:  string representing which dimension the exception is for, the value that has cause the exception
        // Postcondition: ArgumentOutOfRangeException is thrown
        private ArgumentOutOfRangeException ThrowDimensionException(string dimension, double val) =>
            throw new ArgumentOutOfRangeException($"{dimension}", val, $"{dimension} must be > {MIN_DIMENSION}");
        public double Length
        {
            // Precondition:  None
            // Postcondition: The package's _length has been returned
            get => _length;
            // Precondition:  value > 0 (has dimension)
            // Postcondition: sets _length equal to value
            set
            {
                if(value > MIN_DIMENSION) { _length = value; }
                else { ThrowDimensionException("Length", value);  }
            }
        }
        public double Width
        {
            // Precondition:  None
            // Postcondition: The package's _width has been returned
            get => _width;
            // Precondition:  value > 0 (has dimension)
            // Postcondition: sets _width equal to value
            set
            {
                if (value > MIN_DIMENSION) { _width = value;  }
                else { ThrowDimensionException("Width", value); }
            }
        }
        public double Height
        {
            // Precondition:  None
            // Postcondition: The package's _height has been returned
            get => _height;
            // Precondition:  value > 0 (has dimension)
            // Postcondition: sets _height equal to value
            set
            {
                if (value > MIN_DIMENSION) { _height = value; }
                else { ThrowDimensionException("Height", value); }
            }
        }
        public double Weight
        {
            // Precondition:  None
            // Postcondition: The package's _weight has been returned
            get => _weight;
            // Precondition:  value > 0 (has weight)
            // Postcondition: sets _height equal to value
            set
            {
                if (value > MIN_DIMENSION) {  _weight = value; }
                else { ThrowDimensionException("Weight", value); }
            }
        }
        // Precondition:  None
        // Postcondition: A String with the package's data has been returned
        public override string ToString()
        {
            return 
                $"{nameof(Length).ToUpper(),-12}{Length,6:F1} \" " +
                $"\n{nameof(Width).ToUpper(),-12}{Width,6:F1} \" " +
                $"\n{nameof(Height).ToUpper(),-12}{Height,6:F1} \" " +
                $"\n{nameof(Weight).ToUpper(),-12}{Weight,6:F1} lbs " +
                $"\n\n{base.ToString()}";
        }
    }
}

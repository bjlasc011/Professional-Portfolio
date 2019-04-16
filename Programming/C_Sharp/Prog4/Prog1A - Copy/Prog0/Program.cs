// Program 0
// CIS 200-01
// Fall 2018
// Due: 9/10/2017
// By: Andrew L. Wright (students use Grading ID)

// File: Program.cs
// Simple test program for initial Parcel classes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog0.TwoDayAirPackage;
using static Prog0.GroundPackage;

namespace Prog0
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", 
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", 
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", 
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test Letter 3

            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            // Add test data to list
            parcels.Add(l1);
            parcels.Add(l2);
            parcels.Add(l3);

            // Display data
            Console.WriteLine("Program 0 - List of Parcels\n");
            // Loop through and write each parcel obj
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }
            // Create 6 AirPackages: 3 TwoDayAirPackage, 3 NextDayAirPackage
            List<AirPackage> airPackageList = new List<AirPackage>()
            {
            new TwoDayAirPackage(a1, a3, 33.2, 2, 4, 5.0, Delivery.Early),
            new TwoDayAirPackage(a2, a4, 10, 2, 4, 16.3, Delivery.Early ),
            new TwoDayAirPackage(a2, a4, 10, 2, 4, 16.3, Delivery.Saver),
            new NextDayAirPackage(a4, a1, 3.2, 5, 4, 5.0, 11.5m),
            new NextDayAirPackage(a3, a2, 180, 5, 1, 150, 5.99m),
            new NextDayAirPackage(a3, a1, 16, 50, 2, 5.5, 18.75m)
            };
            // Display data
            Console.WriteLine("Prog0 - List of AirPackages\n");
            foreach (AirPackage ap in airPackageList)
            {
                Console.WriteLine($"{ap}\n--------------------");
            }

            List<GroundPackage> groundPackages = new List<GroundPackage>
            {
                new GroundPackage(a3, a2, 2, 5, 3.3, 100 ),
                new GroundPackage(a1, a4, 5, 25, 80, 10),
                new GroundPackage(a4, a3, 8, 1, 4, 0.1)
            };
            Console.WriteLine("Prog0 - List of groundPackages\n");
            foreach (GroundPackage gp in groundPackages)
            {
                Console.WriteLine($"{gp}\n--------------------");
            }
        }
    }
}

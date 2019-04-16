// By: D4823
// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018

// File: TestParcels
// This class contains the programs Main(), which contains test data and outputs the sorted data demonstrating 
// the use of IComparable and Comparer


using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {

        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210);                                 // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901);                 // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101);                      // Test Address 4
            Address a5 = new Address("Manny Rodriguez", "540 Basebasll St", "Kansas City", "MI", 35292);                        // Test Address 5
            Address a6 = new Address("Derek Jeter", "33 Santos Way", "New York City", "NY", 00235);                             // Test Address 6
            Address a7 = new Address("Curt Schilling", "1 Bloody Sock St", "Boston", "MA", 10654);                              // Test Address 7
            Address a8 = new Address("Don Junior", "540 Basebasll St", "Kansas City", "MI", 35292);                             // Test Address 8
            Address a9 = new Address("Nolan Ryan", "540 Basebasll St", "Kansas City", "MI", 28000);                             // Test Address 9
            Address a0 = new Address("Emanuel Chicken III", "Hen House Dr", "New Orleans", "LA", 50412);                        // Test Address 0

            List<Parcel> parcels = new List<Parcel>()   // set parcels list in upv obj
            {
            new TwoDayAirPackage(a3, a0, 5.25, 99, 5, 0.001, TwoDayAirPackage.Delivery.Early),  // TwoDayAirPackage obj, test data
            new Letter(a6, a3, 0.50M),                                                          // letter obj, test data
            new GroundPackage(a8, a3, 15, 5, 2, 3.5),                                           // groundPackage obj, test data
            new Letter(a4, a1, 1.70M),                                                          // letter obj, test data
            new GroundPackage(a9, a1, 15, 5, 2, 3.5),                                           // groundPackage obj, test data
            new NextDayAirPackage(a0, a5, 100, 15, 6, 180, 35.99M),                             // NextDayAirPackage obj, test data
            new Letter(a2, a7, 1.20M),                                                          // letter obj, test data
            new NextDayAirPackage(a8, a3, 15, 5, 2, 180, 3.5M),                                 // NextDayAirPackage obj, test data
            new GroundPackage(a0, a8, 15, 5, 2, 3.5),                                           // groundPackage obj, test data
            new TwoDayAirPackage(a3, a0, 23.4, 4, 1, 0.001, TwoDayAirPackage.Delivery.Early),   // TwoDayAirPackage obj, test data
            new NextDayAirPackage(a8, a4, 11.1, 5.25, 22, 180, 35M),                            // NextDayAirPackage obj, test data
            new TwoDayAirPackage(a3, a0, 10.10, 4, 4, 8.2, TwoDayAirPackage.Delivery.Saver),    // TwoDayAirPackage obj, test data
            };

            GetDesiredUserOutput(out bool verbose); // verbose holds desired bit flag for desired output type
            Clear();                                // clear console output
            
            if (verbose)
            {
                // display original list
                WriteLine("Orginal list:");                 
                parcels.ForEach(p => WriteLine(p));
                Pause();
                
                // display list ordered by Cost
                WriteLine("Sorted list (natural order):");  
                parcels.Sort();
                parcels.ForEach(p => WriteLine(p));
                Pause();

                // display list sorted by desc by zip
                WriteLine("Sorted list (descending natural order) using Comparer:");    
                parcels.Sort(new DescendingDestZip());
                parcels.ForEach(p => WriteLine(p));
                Pause();

                // EXTRA CREDIT
                // display by type, then within each type order desc by cost
                WriteLine("Extra Credit\nSorted list (ascending by Type, descending by cost) using Comparer:"); 
                parcels.Sort(new ParcelAscCostDesc());
                parcels.ForEach(p => WriteLine(p));
                Pause();

            } else {
                // display original list
                WriteLine("Orginal list:");
                parcels.ForEach(p => 
                    WriteLine($"{p.GetType()}\n{p.CalcCost():C2}\n{p.DestinationAddress.Zip:D5}\n"));
                Pause();

                // display list ordered by Cost
                WriteLine("Sorted list (natural order):");
                parcels.Sort();
                parcels.ForEach(p => 
                    WriteLine($"{p.GetType()}\n{p.CalcCost():C2}\n{p.DestinationAddress.Zip:D5}\n"));
                Pause();

                // display list sorted by desc by zip
                WriteLine("Sorted list (descending natural order) using Comparer:");
                parcels.Sort(new DescendingDestZip());
                parcels.ForEach(p => 
                    WriteLine($"{p.GetType()}\n{p.CalcCost():C2}\n{p.DestinationAddress.Zip:D5}\n"));
                Pause();

                // EXTRA CREDIT
                // display by type, then within each type order desc by cost
                WriteLine("Extra Credit\nSorted list (ascending by Type, descending by cost) using Comparer:");
                parcels.Sort(new ParcelAscCostDesc());
                parcels.ForEach(p => 
                    WriteLine($"{p.GetType()}\n{p.CalcCost():C2}\n{p.DestinationAddress.Zip:D5}\n"));
                Pause();
            }
        }

        // Precondition:  variable to hold out bool value
        // Postcondition: user has specified their output type in bool isVerbose.
        private static void GetDesiredUserOutput(out bool isVerbose)
        {
            const string verbose = "0"; //holds const string for ReadLine input comparison
            const string light = "1";   //holds const string for ReadLine input comparison

            Write("0: display all parcel data, \n" +
                  "1: display only Parcel Type, Cost, & Zip \n" +
                  "Choose desired console output: ");
            string input = ReadLine(); //holds user input

            if (input == verbose)           // Lazy compare user input
                isVerbose = true;           // set output to chosen option
            else if (input == light)        // Lazy compare user input
                isVerbose = false;          // set output to chosen option
            else
                GetDesiredUserOutput(out isVerbose); //recurrsively call until the user finally gives us a proper answer
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Clear(); // Clear screen
        }
    }
}

// By: D4823
// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018

// File: TestParcels
// This class contains the programs Main(), which contains test data and outputs the sorted data demonstrating 
// the use of IComparable and Comparer and null obj references for a Parcel obj and a parcel obj that has a null address obj


using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        readonly static string NL = Environment.NewLine;    // new line 
        readonly static string USER = Environment.UserName; // current user

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

            TwoDayAirPackage tdap = new TwoDayAirPackage(a3, a0, 5.25, 99, 5, 0.001, TwoDayAirPackage.Delivery.Early);  // TwoDayAirPackage obj, test data
            Letter nullLetter = new Letter(a4, a1, 1.70M);
            tdap = null;
            nullLetter = null;

            List<Parcel> parcels = new List<Parcel>()                                           // set parcels list in upv obj
            {
            tdap,
            new TwoDayAirPackage(a3, a0, 5.25, 99, 5, 0.001, TwoDayAirPackage.Delivery.Early),  // TwoDayAirPackage obj, test data
            new Letter(a6, a1, 10.50M),                                                         // letter obj, test data
            new GroundPackage(a8, a3, 15, 5, 2, 3.5),                                           // groundPackage obj, test data
            nullLetter,                                                                         // letter obj set to null, test data
            new Letter(a4, a7, 1.20M),                                                          // letter obj, test data
            new Letter(a4, a7, 1.20M),                                                          // letter obj, test data
            new NextDayAirPackage(a5, a3, 100, 15, 6, 180, 5.99M),                              // NextDayAirPackage obj, test data
            new Letter(a2, a0, 1.20M),                                                          // letter obj, test data
            new NextDayAirPackage(a8, null, 15, 5, 2, 180, 3.5M),                               // NextDayAirPackage obj, test data
            new GroundPackage(a0, a8, 15, 5, 2, 3.5),                                           // groundPackage obj, test data
            new TwoDayAirPackage(a3, a2, 23.4, 4, 1, 0.001, TwoDayAirPackage.Delivery.Early),   // TwoDayAirPackage obj, test data
            new NextDayAirPackage(a8, a4, 11.1, 5.25, 22, 180, 35M),                            // NextDayAirPackage obj, test data
            new TwoDayAirPackage(a3, a0, 10.10, 4, 4, 8.2, TwoDayAirPackage.Delivery.Saver),    // TwoDayAirPackage obj, test data
            new NextDayAirPackage(a1, a0, 11.1, 5.25, 22, 180, 35M),                            // NextDayAirPackage obj, test data
            };

            OptimizeConsoleDimension();             // size the console for data to be presented
            GetDesiredUserOutput(out bool verbose); // verbose holds bit flag for desired output type
            Clear();                                // clear console output
            LoopThroughMessages(parcels, verbose);  // display packages to the user.
        }



        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLineWrap("Press Enter to Continue...");
            ReadLine();
            Clear(); // Clear screen
        }



        // Precondition:  variable to hold out bool value
        // Postcondition: user has specified their output type in bool isVerbose.
        private static void GetDesiredUserOutput(out bool isVerbose)
        {
            const string verbose = "1";              // holds const string for ReadLine input comparison
            const string light = "0";                // holds const string for ReadLine input comparison
            WriteLineWrap($"Hello {USER} Choose desired console output{NL}  1\tdisplay all parcel data{NL}  0\tdisplay only Parcel Type, Cost, & Zip");

            string input = ReadLine();               // holds user input

            if (input == verbose)
                isVerbose = true;
            if (input == light)
                isVerbose = false;
            else GetDesiredUserOutput(out isVerbose);
        }



        // Precondition:  List<Parcels> to be output, bool defining the type of output desired (verbose/light)
        // Postcondition: Parcels are Written to the console in the desired format with various sorting methods
        public static void LoopThroughMessages(List<Parcel> parcels, bool isVerbose)
        {
  /*const*/ string DIVIDER = new String('_', 35); // divides package start and end (const not allowed for new String() syntax)
            const int SORT_COUNT = 4;             // number of sorts to demonstrate.
            for (int i = 0; i < SORT_COUNT; ++i)
            {
                switch (i)
                {
                    case 0:
                        WriteLineWrap($"Orginal list:{NL}");
                        break;
                    case 1:
                        WriteLineWrap($"Sorted list (natural order - cost):{NL}");
                        parcels.Sort();
                        break;
                    case 2:
                        WriteLineWrap($"Sorted list (descending natural order - zip) using Comparer:{NL}");
                        parcels.Sort(new DescendingDestZip());
                        break;
                    case 3:
                        WriteLineWrap($"Extra Credit{NL}Sorted list (ascending by Type, descending by cost) using Comparer:{NL}");
                        parcels.Sort(new ParcelAscCostDesc());
                        break;
                }
                if (isVerbose)
                {
                    parcels.ForEach(p => {
                        WriteLineWrap($"{DIVIDER}");
                        if (p != null)
                            WriteLineWrap($"{p}");
                        else WriteLineWrap($"NULL PARCEL REFERENCE");
                    });
                }
                else
                {
                    parcels.ForEach(p => {
                        WriteLineWrap($"{DIVIDER}");
                        if (p != null)
                        {
                            WriteLineWrap($"{p.GetType()}{NL}{p.CalcCost():C2}");
                            if (p.DestinationAddress != null)
                                WriteLineWrap($"{p.DestinationAddress.Zip:D5}");
                            else WriteLineWrap($"NULL DEST. ADDRESS REFERENCE");
                        }
                        else WriteLineWrap($"NULL PARCEL REFERENCE");
                    });
                }
                Pause();
            }
        }



        // Precondition:  none
        // Postcondition: sets console to a tall and skinny console dimensions without being larger 
        //                than the display screen dimensions
        public static void OptimizeConsoleDimension()
        {
            const int SPACER = 3,                               // number of rows we want the console height to be less than display height
                      WIDTH_TARGET = 46;                        // how many chars wide should the console be
            int MAX_HEIGHT = Console.LargestWindowHeight;       // Console properties can't be set to constant Int... holds max window height based on view screen
            int targetH = MAX_HEIGHT - SPACER;                  // desired console height      
            int targetW = (WIDTH_TARGET);                       // desired console width
            if (WIDTH_TARGET + SPACER > MAX_HEIGHT)
                targetW = MAX_HEIGHT - SPACER;

            SetWindowSize(targetW, targetH);
            Console.BufferWidth = targetW;                              // how wide should output be allowed to be?
        }



        // Precondition:  string that we want to write to the console
        // Postcondition: writes the string to the console with entire words wrapping to next line
        public static void WriteLineWrap(string wordBlob)
        {
            const int TAB_SIZE = 4;                                     // tab size in number of spaces
            char space = ' ';                                           // space char
            int spaceLen = 1;                                           // adds readability to hold length of space (1)
            string tab = new String(space, TAB_SIZE);                   // tab as concat spaces 

            List<string> lines = wordBlob                               // each line from the word blob split by ENV NL
                .Replace("\t", tab)
                .Split(new string[] { NL }, StringSplitOptions.None)
                .ToList();

            lines.ForEach(l =>
            {
                int lineCharCount = 0;                        // keep track of number of chars we have written to each line in console
                List<string> words = l.Split(space).ToList(); // list of words we have per line

                if (l.TrimEnd().Count() < WindowWidth)
                    WriteLine(l.TrimEnd());
                else
                {
                    words.ForEach(w =>
                    {
                        if ((lineCharCount + w.Length + spaceLen) < WindowWidth)
                        {
                            Write(w + space);
                            lineCharCount += w.Length + spaceLen;
                        }
                        else
                        {
                            Write(NL + w + space);
                            lineCharCount = w.Length + spaceLen;
                        }
                    });
                    WriteLine();
                }
            });
        }
    }
}

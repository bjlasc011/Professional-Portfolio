//GRADING ID: D4823 
//PROGRAM: Prog2 
//DUE DATE: 10 / 24 / 2018
//CLASS-SEC: CIS 200-01

//DESCRIPTION: This is a form that displays an address input modal, a parcel
//             creation modal, and display the lists of addresses or parcels
using Prog2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        //
        // **************** VAR DECLARATIONS ****************
        internal UserParcelView upv = new UserParcelView(); // upv is an instance of UserParcelView
        private enum MainText { none, address, parcel};     // Enum types of information that can be displayed in label box
        MainText MainTextState { get; set; }                // MainTextState holds the current Enum value that represents the info displayed in main label
        AboutForm aboutForm = new AboutForm();              // instance of the aboutForm. Will only need one and will not need to be destroyed until app closes
        const string THICK_LINE = "===========================";    // const string used in output of letters and addresses
        readonly string NL = Environment.NewLine;           // readonly const to hold new line in output


        // precondition:    none
        // postcondition:   instantiates Prog2Form
        public Prog2Form()
        {
            InitializeComponent();
        }
        //
        // **************** LOAD MAIN FORM ****************
        // precondition:    sender obj, Prog2Form has fired Load event
        // postcondition:   sets MainTextState to reflect content being displayed (none)
        private void Prog2Form_Load(object sender, EventArgs e)
        {
            MainTextState = MainText.none; // intialized MainTextState
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210);                                 // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901);                 // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101);                      // Test Address 4
            Address a5 = new Address("Manny Rodriguez", "540 Basebasll St", "Kansas City", "MI", 35292);                        // Test Address 5
            Address a6 = new Address("Derek Jeter", "33 Santos Way", "New York City", "NY", 00235);                             // Test Address 6
            Address a7 = new Address("Curt Schilling", "1 Bloody Sock St", "Boston", "MA", 10654);                              // Test Address 7
            Address a8 = new Address("Don Junior", "540 Basebasll St", "Kansas City", "MI", 35292);                             // Test Address 8
            Address a9 = new Address("Manny Rodriguez", "540 Basebasll St", "Kansas City", "MI", 28000);                        // Test Address 9

            upv.addresses = new List<Address>() { a1, a2, a3, a4, a5, a6, a7, a8, a9 }; // address list in upv obj
            upv.parcels = new List<Parcel>() // set parcels list in upv obj
            {
            new Letter(a6, a3, 0.50M), // letter obj, test data
            new Letter(a2, a7, 1.20M), // letter obj, test data
            new Letter(a4, a1, 1.70M), // letter obj, test data

            new GroundPackage(a8, a3, 15, 5, 2, 3.5), // groundPackage obj, test data
            new GroundPackage(a2, a8, 15, 5, 2, 3.5), // groundPackage obj, test data
            new GroundPackage(a9, a1, 15, 5, 2, 3.5)  // groundPackage obj, test data
            };
        }
        //
        // **************** ABOUT DIALOG ****************
        // precondition:    About toolStrip menu Item clicked, sender obj
        // postcondition:   presents "About" dialog
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e){
            aboutForm.ShowDialog();
        }
        //
        // **************** EXIT APP ****************
        // precondition:    Exit toolStrip menu Item clicked, sender obj
        // postcondition:   Exits out of entire application
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }
        //
        // **************** ADDRESS DIALOG ****************
        // precondition:    Address toolStrip menu Item clicked, sender obj
        // postcondition:   presents "Address" dialog form and adds
        private void AddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // instantiate AddressForm object
            DialogResult result;                            // dialog result for addressForm
            result = addressForm.ShowDialog();              // show addressFrom dialog
            try
            {
                if (result == DialogResult.OK && addressForm.ValidateChildren())
                {
                    if (string.IsNullOrWhiteSpace(addressForm.Address2Input)) // Address2Input null || w.Space?
                    {
                        upv.AddAddress(addressForm.NameInput, addressForm.AddressInput, addressForm.Address2Input,
                            addressForm.CityInput, addressForm.StateInput, addressForm.ZipInput);
                    }
                    else // no Address2
                    {
                        upv.AddAddress(addressForm.NameInput, addressForm.AddressInput,
                            addressForm.CityInput, addressForm.StateInput, addressForm.ZipInput);
                    }
                }
                ResetForm(addressForm); // dispose of form and release resources
                UpdateMainText(MainTextState); // update maintext displayed to show new address or letter, dependent on the currently displayed context
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        // **************** LETTER DIALOG ****************
        // precondition:    Letter toolStrip menu Item clicked, sender obj
        // postcondition:   presents "Letter" dialog form and adds letter obj if correclty input
        private void LetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm = new LetterForm(upv.AddressList);    // instatiate letter form
            DialogResult dialogResult = letterForm.ShowDialog();        // letter Form dialog Result
            try
            {
                if (dialogResult == DialogResult.OK) // Was OK sent as dialog result
                {
                    int oInd = letterForm.OriginAddressInd; // origin index (readability)
                    int dInd = letterForm.DestAddressInd;   // dest index (readability)
                    // are letters the same string (we already tested are they the same index)
                    if (letterForm.AddressList[oInd].ToString() != letterForm.AddressList[dInd].ToString())
                    {
                        // add letter to List<Letter>
                        upv.AddLetter(
                            letterForm.AddressList[letterForm.OriginAddressInd],
                            letterForm.AddressList[letterForm.DestAddressInd],
                            decimal.Parse(letterForm.FixedCostTextBox)
                       );
                    }
                    else
                    {
                        MessageBox.Show("Unable to create letter. Addresses cannot be the Same!");
                    }
                }
                ResetForm(letterForm);          // Dispose of form and release all resources
                UpdateMainText(MainTextState);  // Update main information label if currently displaying letters
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        // **************** LIST ADDRESS ****************
        // precondition:    List Address toolStrip menu Item clicked, sender obj
        // postcondition:   displays Address list to the main label displayed on main form
        private void ListAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextState = MainText.address; // set mainText state to reflect that the address list is being displayed
            UpdateMainText(MainTextState);
        }
        //
        // **************** LIST PARCELS ****************
        // precondition:    List Parcels toolStrip menu Item clicked, sender obj
        // postcondition:   displays Address list to the main label displayed on main form
        private void ListParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextState = MainText.parcel;
            UpdateMainText(MainTextState);
        }
        //
        // **************** FORM DISPOSE ****************
        // precondition:    the Form instance we want to dispose
        // postcondition:   clears the form and releases all resources
        private void ResetForm(Form form)
        {
            form.Dispose();
        }
        //
        // **************** UPDATE MAIN TEXT ****************
        // precondition:    the desired MainText is passed as a param
        // postcondition:   outputs the desired information based on the param
        private void UpdateMainText(MainText state)
        {
            if (state == MainText.address) //show addresses?
            {
                StringBuilder allAddresses = new StringBuilder();   // this is the big string of all address
                foreach (Address a in upv.addresses)                // step through all addresses
                {
                    allAddresses.Append(a + NL + THICK_LINE + NL);  // append this adderess
                }
                MainTextBox.Text = allAddresses.ToString();         //set MainTextBox to show addresses
            }
            else if(state == MainText.parcel)                       //show parcels?
            {
                StringBuilder allParcels = new StringBuilder();     // this is the big string of all the parcels
                foreach (Parcel p in upv.parcels)
                {
                    allParcels.Append(p + NL + THICK_LINE + NL);    // append this to allParcels
                }
                MainTextBox.Text = allParcels.ToString();           //set MainTextBox to show addresses
            }
        }
    }
}


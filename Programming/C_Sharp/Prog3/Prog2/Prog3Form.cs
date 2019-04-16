// By: D4823
// Program 3
// CIS 200-01
// Fall 2018
// Due: 10/25/2018

// File: Prog3Form.cs
// This class creates the main GUI for Program 3. It provides a
// File menu with About and Exit items, an Insert menu with Address and
// Letter items, an Edit Address menu option, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Prog2;

namespace UPVApp
{
    public partial class Prog3Form : Form
    {
        private UserParcelView upv;                 // The UserParcelView
        readonly string NL = Environment.NewLine;   // Cleaner string interpolation
        
        // enum for managing reporting state, so when packages or addresses change
        private enum Reporting { Addresses, Parcels, None }
        private Reporting reportState;  // holds state of the current report text being displayed

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog3Form()
        {
            InitializeComponent();
            upv = new UserParcelView();     // init upv
            reportState = Reporting.None;   // init reportState
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Program 3{NL}By: D4823{NL}CIS 200-01{NL}Fall 2018",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address

                    RefreshReport(); // refresh reportTxt.Text to show new address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputAddresses(); // reportTxt.Text set => Addresses
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted

                    RefreshReport(); // update reportTxt.Text
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose();
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputParcels();
        }

        // Precondition:  File, Open menu item activated
        // Postcondition: the chosen file is deserialized, then the upv is set to deserialized data, 
        //                and the reportTxt.Text is updated to reflect the new data.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; // file explorer dialog result

            using (var openFile = new OpenFileDialog()) // using statement to create open file resource
            {
                openFile.CheckFileExists = false;   // we don't care...
                result = openFile.ShowDialog();     // set result

                if (result == DialogResult.OK) //if OK =>
                {
                    if (!string.IsNullOrWhiteSpace(openFile.SafeFileName)) // did user pick a file
                    {
                        FileStream fileStream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        try
                        {
                            upv = (UserParcelView)binaryFormatter.Deserialize(fileStream);
                            RefreshReport();
                            reportTxt.Text = $"\"Open\" was a SUCCESS {NL} {openFile.SafeFileName}: uploaded success" 
                                + NL + NL + reportTxt.Text;
                        }
                        catch (FileNotFoundException ex_nf)
                        {
                            MessageBox.Show($"File Not Found: {ex_nf.Message}");
                        }
                        catch (ArgumentNullException ex_null)
                        {
                            MessageBox.Show($"Null FileStream Exception: {ex_null.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Cannot Deserialize: {ex.Message}");
                        } // no generic catch block needed bc all other exceptions are wrapped as an Exception
                        finally
                        {
                            fileStream.Close(); // return resources
                        }
                    }
                }
            }
        }
        
        // Precondition:  File, Save As menu item activated
        // Postcondition: The current upv object is serialized into the designated file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;    // file explorer dialog result

            using (var saveFile = new OpenFileDialog())  // using statement to create open file resource
            {
                saveFile.CheckFileExists = false;   // we don't care if it already exists
                result = saveFile.ShowDialog();     // set result

                if (result == DialogResult.OK) //if OK =>
                {
                    if (!string.IsNullOrWhiteSpace(saveFile.SafeFileName)) // shouldn't be saving a null filename
                    {
                        FileStream fileStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.ReadWrite);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        try
                        {
                            binaryFormatter.Serialize(fileStream, upv); //serialize upv to filestream
                            reportTxt.Text = "\"Save As\" was a SUCCESS" + NL + NL + reportTxt.Text; //let user know it worked
                        }
                        catch (SerializationException ex_ser)
                        {
                            MessageBox.Show($"Serialization Exception: {ex_ser.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Exception: {ex.Message}");
                        }
                        finally
                        {
                            fileStream.Close(); // return fileStream resources
                        }
                    }
                }
            }
        }
        
        // Precondition:  Edit > Address menu item activated
        // Postcondition: All addresses are displayed. The Address the user selects is editable. The 
        //                edits are saved to the selected address in the upv AddressList
        private void addressEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Address address;    // address to hold
            int index;              // index of selected address
            AddressEditForm addressEditForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog

            if(upv.AddressList.Count <= 0) // we need addresses to display
            {
                MessageBox.Show("No addresses have been created.");
            }
            else // we have addresses to display
            {
                addressEditForm = new AddressEditForm(upv.AddressList); // Send list of addresses
                result = addressEditForm.ShowDialog(); // set result

                if (result == DialogResult.OK) // Only add if OK
                {
                    index = addressEditForm.SelectedAddressIndex; // set index to the index of selected address prop from form

                    address = upv.AddressAt(index); // get address ref at the selected addresses index and set to a tempAddress

                    AddressForm addressForm = new AddressForm() // create address form and set Props to tempAddress Props
                    {
                        AddressName = address.Name,
                        Address1 = address.Address1,
                        Address2 = address.Address2,
                        City = address.City,
                        State = address.State,
                        ZipText = address.Zip.ToString()
                    };
                    
                    DialogResult editResult = addressForm.ShowDialog();     // set edit results
                    if (editResult == DialogResult.OK)
                    {
                        //We trust the validation being don in the AddressForm, we can safely use parse instead of tryparse zip
                        address.Name = addressForm.AddressName;
                        address.Address1 = addressForm.Address1;
                        address.Address2 = addressForm.Address2;
                        address.City = addressForm.City;
                        address.State = addressForm.State;
                        address.Zip = int.Parse(addressForm.ZipText);

                        RefreshReport();    // refresh report
                    }
                    addressForm.Dispose();  // return resources
                }
                addressEditForm.Dispose();  // return resources
            }
        }
        
        // Precondition:  none
        // Postcondition: sets reporTxt.Text to display Parcels, updates the reporting state to Parcel
        private void OutputParcels()
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL); 

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;

            reportState = Reporting.Parcels;
        }

        // Precondition:  none
        // Postcondition: sets reporTxt.Text to display Addresses, updates the reporting state to Address
        private void OutputAddresses()
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();
            reportTxt.AppendText(NL);

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;

            reportState = Reporting.Addresses;
        }

        // Precondition:  none
        // Postcondition: updates the view of the data being displayed in the reportTxt.Text
        private void RefreshReport()
        {
            if(reportState == Reporting.Parcels)
            {
                OutputParcels();
            }
            else if(reportState == Reporting.Addresses)
            {
                OutputAddresses();
            }
        }
    }
}
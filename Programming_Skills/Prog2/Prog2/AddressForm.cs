//GRADING ID: D4823 
//PROGRAM: Prog2 
//DUE DATE: 10 / 24 / 2018
//CLASS-SEC: CIS 200-01

//DESCRIPTION: This is a form that displays an address input modal, a parcel
//             creation modal, and display the lists of addresses or parcels

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{
    // AddressForm class is used to create the Address Form and is used to create address objects
    public partial class AddressForm : Form
    {
        // AddressFields enum holds control names
        public enum AddressFields { nameTextBox, addressTextBox, address2TextBox, cityTextBox, stateComboBox, zipTextBox }

        // Property form name input
        // precondition:    none
        // postcondition:   the string of the Text attribute is returned
        internal string NameInput       { get => nameTextBox.Text; }

        // Property form address line 1 input
        // precondition:    none
        // postcondition:   the string of the Text attribute is returned
        internal string AddressInput    { get => addressTextBox.Text; }

        // Property form address line 2 input
        // precondition:    none
        // postcondition:   the string of the Text attribute is returned
        internal string Address2Input   { get => address2TextBox.Text; }

        // Property form city input
        // precondition:    none
        // postcondition:   the string of the Text attribute is returned
        internal string CityInput       { get => cityTextBox.Text; }

        // Property form state input
        // precondition:    none
        // postcondition:   the string of the Text attribute is returned
        internal string StateInput      { get => stateComboBox.Text; }

        // Property form zip input
        // precondition:    none
        // postcondition:   the int of the parsed from the Text attribute is returned
        internal int ZipInput           { get => int.Parse(zipTextBox.Text); }

        // AddressForm Constructor
        public AddressForm()
        {
            InitializeComponent(); // initialize component
        }

        // precondition:    click event emitted, sender oject passed as param
        // postcondition:   sets the DialogResult to OK
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // precondition:    click event emitted, sender oject passed as param
        // postcondition:   sets the DialogResult to Cancel
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        //**************** VALIDATION ****************//

        // precondition:    CancelEvent emitted, sender oject passed as param
        // postcondition:   Validates data by either canceling or completing the validating event. 
        //                  Sets the AddressErrorProvider if invalid. Allows focus change if valid.
        private void InputFeild_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = false; // Bool to hold validity
            if (sender is Control inputControl &&
                  Enum.TryParse(inputControl.Name, out AddressFields inputName))
            {
                // switch through Control Names
                switch (inputName)
                {
                    case AddressFields.zipTextBox:
                        if (int.TryParse(inputControl.Text, out int zipAsInt))
                            isValid = CheckValid(zipAsInt);
                        HandleValidity(inputControl, e, isValid);
                        break;
                    default:
                        isValid = CheckValid(inputControl.Text);
                        HandleValidity(inputControl, e, isValid);
                        break;
                }
            }
            else
            {

                throw new Exception("Why are are validating things that aren't controls? How are we? What... Whyyy?");
            }
        }

        // precondition:    validated event emitted, sender oject passed as param
        // postcondition:   removes any existing erors in the AddressErrorProvider
        private void InputFeild_Validated(object sender, EventArgs e)
        {
            AddressErrorProvider.SetError((Control)sender, ""); // reset AddressErrorProvider
        }

        // precondition:    string that is not null and not white space
        // postcondition:   returns bool representing if field is valid
        private bool CheckValid(string formField) => !string.IsNullOrWhiteSpace(formField);

        // precondition:    a positive int that is less than 99,999
        // postcondition:   returns bool representing if field is valid
        private bool CheckValid(int formField)
        {
            const int MIN_ZIP = 0,     // Minimum ZipCode value
                      MAX_ZIP = 99999; // Maximum ZipCode value
            return (formField >= MIN_ZIP && formField <= MAX_ZIP);
        }


        //**************** UTIL METHODS ****************//

        // precondition:    Control as the sender, CancelEvent event is emitted, and bool for state of validity
        // postcondition:   Cancels validity event if invalid and set error provider 
        //                  OR allows Validated event if valid
        private void HandleValidity(Control sender, CancelEventArgs e, bool isValid)
        {
            if (!isValid)
            {
                e.Cancel = true;    // cancel validation event = true
                sender.Focus();
                AddressErrorProvider.SetError(sender, "Whao there cowboy! Try giving us a valid input?!");
            }
        }
    }
}

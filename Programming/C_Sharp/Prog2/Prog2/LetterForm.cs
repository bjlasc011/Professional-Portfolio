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
    // LetterForm is used to create letter objects from a list of supplied addresses passed through the constructor
    public partial class LetterForm : Form
    {
        // public enum used to enumerate input fields on the form
        public enum LetterFields { originAddressComboBox, destAddressComboBox, fixedCostTextBox }
        
        internal int OriginAddressInd
        {
            // precondition:    none
            // postcondition:   gets Index of the selected originAddress
            get => originAddressComboBox.SelectedIndex;
        }
        internal int DestAddressInd
        {
            // precondition:    none
            // postcondition:   gets Index of the destination Address
            get => destAddressComboBox.SelectedIndex;
        }
        internal string FixedCostTextBox
        {
            // precondition:    none
            // postcondition:   gets Text string of the fixed cost text box
            get => fixedCostTextBox.Text;
        }

        // List of Address obj
        internal List<Address> AddressList
        {
            // precondition:    none
            // postcondition:   gets the value of auto-backingfield
            get;
            // precondition:    none
            // postcondition:   sets the value of the auto-backingfield
            set;
        }

        // precondition:    List of address objs (used to populate dropdown list)
        // postcondition:   constructs a LetterForm instance
        public LetterForm(List<Address> addressList)
        {
            InitializeComponent();
            AddressList = addressList; // set internal prop AddressList
        }


        // precondition:    sender Obj, Load event emitted
        // postcondition:   constructs a LetterForm instance
        private void LetterForm_Load(object sender, EventArgs e)
        {
            foreach(var a in AddressList)
            {
                originAddressComboBox.Items.Add(a.Name); //populate drop down list ORIGIN
                destAddressComboBox.Items.Add(a.Name);  //populate drop down list DEST
            }
        }

        // precondition:    sender Obj, click event for the OkButton Emited
        // postcondition:   sets dialogResult to ok if form children are valid, else does nothing
        private void OkButton_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // precondition:    sender Obj, click event for the cancelButton Emited
        // postcondition:   sets dialogResult to cancel
        private void CancelButton_Click_1(object sender, EventArgs e)
        {
                this.DialogResult = DialogResult.Cancel;
        }


        //**************** VALIDATION ****************//

        // precondition:    sender Obj, focus has attempted to change from control
        // postcondition:   validates control's inputs, allows validated event to occur OR
        //                  if control input is invalid: emit set e.cancel to true
        private void InputFeild_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = false; // tracks control's input's validity
            if (sender is Control inputControl &&
                  Enum.TryParse(inputControl.Name, out LetterFields inputName))
            {
                // switch to find proper validity handler
                switch (inputName)
                {
                    case LetterFields.fixedCostTextBox:
                        if (decimal.TryParse(inputControl.Text, out decimal fixedCost))
                            isValid = CheckValid(fixedCost);
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

        // precondition:    sender Obj, Validating event has completed validation successfully
        // postcondition:   sets LetterErrorProvider to show no error
        private void InputFeild_Validated(object sender, EventArgs e)
        {
            LetterErrorProvider.SetError((Control)sender, "");
        }

        // precondition:    the chosen Origin and Dest address Indicies are != ; 
        //                  The string being passed is not null or white space
        // postcondition:   returns a bool that answers the question, "is this input valid"
        private bool CheckValid(string formField)
        {
            int oInd = originAddressComboBox.SelectedIndex; // int to hold the selected Origin index
            int dInd = destAddressComboBox.SelectedIndex; // int to hold the selected Destination index

            bool isValid = (originAddressComboBox.SelectedIndex != destAddressComboBox.SelectedIndex)  && !string.IsNullOrWhiteSpace(formField);
            return isValid;
        }

        // precondition:    the chosen Origin and Dest address Indicies are != ; 
        //                  The decimal being passed positive
        // postcondition:   returns a bool that answers the question, "is this input valid"
        private bool CheckValid(decimal formField)
        {
            const int MIN_COST = 0;    // Minimum fixed Cost
            return (formField >= MIN_COST);
        }

        // precondition:    the sender is a vaild control, the cancelEvent has been passed, and the current state of validity is passed as a bool
        // postcondition:   if Valid: do nothing
        //                  if invalid: cancel validating event and set LetterErrorProvider
        private void HandleValidity(Control sender, CancelEventArgs e, bool isValid)
        {
            if (!isValid)
            {
                e.Cancel = true;
                sender.Focus();
                LetterErrorProvider.SetError(sender, "Whao there cowboy! Try giving us a valid input?!");
            }
        }


    }
}

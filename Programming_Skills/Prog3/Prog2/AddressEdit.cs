// By: D4823
// Program 3
// CIS 200-01
// Fall 2018
// Due:  Monday, November 12 (by 11:59 PM)

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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{
    public partial class AddressEditForm : Form
    {
        // enum to hold column width values in pixels
        private enum ColumnWidth
        {
            ExtraSmall = 50,
            Small = 80,
            Medium = 100,
            Large = 150,
            ExtraLarge = 200
        }
        // enum to hold current filter setting
        private enum FilterBy { Name, Address, City, State, Zip }

        // hold current filter type
        private FilterBy FilterState;
        internal List<Address> Addresses
        {
            // Precondition:  none
            // Postcondition: returns Addresses
            get;
            // Precondition:  none
            // Postcondition: sets Addresses property to value
            set;
        }
        //needed to pull the Address by index and then compare the item to the List<Address>
        internal List<Address> FilteredAddresses
        {
            // Precondition:  none
            // Postcondition: returns FilteredAddresses
            get;
            // Precondition:  none
            // Postcondition: sets FilteredAddresses property to value
            set;
        }
        internal int SelectedAddressIndex
        {
            // Precondition:  none
            // Postcondition: returns SelectedAddressIndex
            get;
            // Precondition:  none
            // Postcondition: sets SelectedAddressIndex property to value
            set;
        }

        // Precondition:  List<Addresses> to initialize Form
        // Postcondition: sets SelectedAddressIndex property to value
        public AddressEditForm(List<Address> addresses)
        {
            InitializeComponent();
            Addresses = addresses; // set addresses to List passed as param
        }

        // Precondition:  Form is called
        // Postcondition: sets attributes of addressListView Control, table created, 
        //                no address selected yet, form loaded 
        private void AddressEditForm_Load(object sender, EventArgs e)
        {
            addressListView.View = View.Details;    // we want to see all of the columns
            addressListView.GridLines = true;       // we want lines for the table
            addressListView.FullRowSelect = true;   // we want to select the entire row

            TableSchemaInit();                      // init the table structure
            GenerateTableData(Addresses);           // init the data into the table we just made
            addressListView.SelectedItems.Clear();  // clear any default selections
            nameRadioBtn.Checked = true;            // set name radio button checked
            FilterState = FilterBy.Name;            // set filter to name by default
            filterTxt.Select();                      // set focus becuase why should the user have to move the mouse?
        }

        // Precondition:  edit button clicked
        // Postcondition: sets SelectedAddressIndex prop to index of selected prop, returns a DialogResult.OK
        private void EditButton_Click(object sender, EventArgs e)
        {
            int selectedItemsCount = addressListView.SelectedItems.Count;  // We want something to be selected 
            if (selectedItemsCount > 0)    // if user selected address
            {
                //find the match between Filtered and the original List<Address> and 
                //return the index, this is because the filter list's indexes do not match
                SelectedAddressIndex = Addresses.IndexOf(FilteredAddresses[addressListView.SelectedIndices[0]]); 
                this.DialogResult = DialogResult.OK;    // set dialog result
            }
            else
            {
                MessageBox.Show("No Address has been selected to edit yet!"); // why edit something that doesn't exist yet
            }
        }

        // Precondition:  none
        // Postcondition: table columns are set to Address Properties 
        private void TableSchemaInit()
        {
            // Set widths according to sizes defined in enum
            int[] columnWidths = new int[] 
            {
                (int)ColumnWidth.Large,
                (int)ColumnWidth.ExtraLarge,
                (int)ColumnWidth.Medium,
                (int)ColumnWidth.Small,
                (int)ColumnWidth.ExtraSmall,
                (int)ColumnWidth.ExtraSmall
            };

            // set clumn names in array
            string[] columnNames = new string[]
            {
                "Name","Address1","Address2","City","State","Zip"
            };

            // create empty array of column headers with a length of 6
            ColumnHeader[] columnHeaders = new ColumnHeader[6];

            for (int i = 0; i < columnNames.Length; ++i) // loop through parrallel arrays and set addressListView.Columns
            {
                addressListView.Columns.Add(columnNames[i], columnWidths[i], HorizontalAlignment.Left);
            }
        }

        // Precondition:  none
        // Postcondition: Addresses are populated in the addressListView control
        private void GenerateTableData(List<Address> _addresses)
        {
            addressListView.Items.Clear();
            string[] fields = new string[6];            // array to hold each 
            ListViewItem addressRecord;                 // will be reused in each iterration to hold Address Reco
            foreach(Address a in _addresses)   // loop through addresses and set fields to Address Props
            {
                fields[0] = a.Name;
                fields[1] = a.Address1;
                fields[2] = a.Address2;
                fields[3] = a.City;
                fields[4] = a.State;
                fields[5] = a.Zip.ToString();

                addressRecord = new ListViewItem(fields); // set array of fields to addressRecord/Row
                addressListView.Items.Add(addressRecord); // add addressRecord to table
            }
        }

        // Precondition:  cancel button clicked
        // Postcondition: dialog result is cancel, we close the form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Precondition:  filterText input has changed
        // Postcondition: the addresses displayed are filtered based on 
        //                the radio button choice and the input text
        private void FilterTxt_TextChanged(object sender, EventArgs e)
        {
            string filterStr = filterTxt.Text.ToUpper();
            // we search based on the filter state (which represents currently checked radio button)
            switch (FilterState)
            {
                case FilterBy.Name:
                    FilteredAddresses = 
                        Addresses.Select(a => a)
                                 .Where(a => a.Name.ToUpper().Contains(filterStr))
                                 .ToList();
                    break;
                case FilterBy.Address:
                    FilteredAddresses =
                        Addresses.Select(a => a)
                                 .Where(a => a.Address1.ToUpper().Contains(filterStr) ||
                                             a.Address2.ToUpper().Contains(filterStr))
                                 .ToList();
                    break;
                case FilterBy.City:
                    FilteredAddresses = 
                        Addresses.Select(a => a)
                                 .Where(a => a.City.ToUpper().Contains(filterStr))
                                 .ToList();
                    break;
                case FilterBy.State:
                    FilteredAddresses = 
                        Addresses.Select(a => a)
                                 .Where(a => a.State.ToUpper().Contains(filterStr))
                                 .ToList();
                    break;
                case FilterBy.Zip:
                    FilteredAddresses =
                        Addresses.Select(a => a)
                                 .Where(a => a.Zip.ToString().ToUpper().Contains(filterStr))
                                 .ToList();
                    break;
            }
            GenerateTableData(FilteredAddresses);
        }

        // Precondition:  any radio button has changed
        // Postcondition: the FilterState is changed to mirror the radio button chosen.
        private void FilterRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            filterTxt.Text = ""; //reset the filter
            filterTxt.Select(); // refocus cursor to avoid annoying transition back to mouse to click on search input field
            const int MAX_STATE_LEN = 2;
            const int MAX_ZIP_LEN = 5;
            const int DEFAULT_LEN = 500;
            //set the state depending on which radio button is now checked
            //setmax length depending on filter type.
            if (nameRadioBtn.Checked)
            {
                FilterState = FilterBy.Name;
                filterTxt.MaxLength = DEFAULT_LEN;
            }
            else if (cityRadioBtn.Checked)
            {
                FilterState = FilterBy.City;
                filterTxt.MaxLength = DEFAULT_LEN;
            }
            else if (stateRadioBtn.Checked)
            {
                FilterState = FilterBy.State;
                filterTxt.MaxLength = MAX_STATE_LEN;
            }
            else if (addressRadioBtn.Checked)
            {
                FilterState = FilterBy.Address;
                filterTxt.MaxLength = DEFAULT_LEN;
            }
            else if (zipRadioBtn.Checked)
            {
                FilterState = FilterBy.Zip;
                filterTxt.MaxLength = MAX_ZIP_LEN;
            }
        }
    }
}

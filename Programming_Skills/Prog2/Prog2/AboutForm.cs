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
    public partial class AboutForm : Form
    {
        readonly string NL = Environment.NewLine;
        public AboutForm()
        {
            InitializeComponent();
            aboutLabel.Text =
                $"GRADING ID: D4823 {NL}{NL}" +
                $"PROGRAM: Prog2 {NL}{NL}" +
                $"DUE DATE: 10 / 24 / 2018 {NL}{NL}" +
                $"CLASS-SEC: CIS 200-01 {NL}{NL}" +
                $"DESCRIPTION: This is a form that displays an address input modal, a parcel creation modal, and display the lists of addresses or parcels";
        }
    }
}

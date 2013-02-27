using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HPCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(475, 320); // Sets the Size of the program.
            this.FormBorderStyle = FormBorderStyle.Fixed3D; // This option makes sure you're not allowed to change the Form Size while program is running. 
            new Main(this); // Sends this Form to the Main class.
        }
    }
}
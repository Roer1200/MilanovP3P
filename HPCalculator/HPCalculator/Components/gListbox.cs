using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HPCalculator.Components
{
    class gListbox : ListBox
    {
        public gListbox(Form1 aForm, string aName, Point aLocation, Size aSize, List<string> aItems, int aFontSize)
        {
            this.Name = aName;
            this.Location = aLocation;
            this.Size = aSize;
            foreach (string s in aItems)
            {
                this.Items.Add(s);
            }

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = Color.Black;

            aForm.Controls.Add(this);
        }
    }
}
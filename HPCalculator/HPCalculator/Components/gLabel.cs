using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HPCalculator.Components
{
    class gLabel : Label
    {
        public gLabel(Form1 aForm, string aName, Point aLocation, Size aSize, string aText, int aFontSize)
        {
            this.Name = aName;
            this.Location = aLocation;
            this.Size = aSize;
            this.Text = aText;

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = Color.Black;

            aForm.Controls.Add(this);
        }
    }
}
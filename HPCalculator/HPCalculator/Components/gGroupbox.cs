using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HPCalculator.Components
{
    class gGroupbox : GroupBox
    {
        public gGroupbox(Form1 aForm, Point aLocation, string aText, Size aSize, int aFontSize)
        {
            this.Location = aLocation;
            this.Text = aText;
            this.Size = aSize;

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = Color.Black;

            aForm.Controls.Add(this);
        }
    }
}

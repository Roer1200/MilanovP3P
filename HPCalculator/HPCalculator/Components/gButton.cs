using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HPCalculator.Components
{
    class gButton : Button
    {
        public gButton(Form1 aForm, string aName, Point aLocation, string aText, Size aSize, Color aForeColor, int aFontSize, EventHandler aClick)
        {
            this.Name = aName;
            this.Location = aLocation;
            this.Size = aSize;
            this.Text = aText;

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = aForeColor;

            this.Click += aClick;

            aForm.Controls.Add(this);
        }

        public gButton(Form1 aForm, string aName, Point aLocation, string aText, Size aSize, Color aForeColor, int aFontSize)
        {
            this.Name = aName;
            this.Location = aLocation;
            this.Size = aSize;
            this.Text = aText;

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = aForeColor;

            aForm.Controls.Add(this);
        }
    }
}
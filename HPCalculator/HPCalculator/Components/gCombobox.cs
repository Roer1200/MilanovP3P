using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HPCalculator.Components
{
    class gCombobox : ComboBox
    {
        public gCombobox(Form1 aForm, string aName, Point aLocation, Size aSize, int aFontSize)
        {
            this.Name = aName;
            this.AllowDrop = true;
            this.FormattingEnabled = true;
            this.Items.AddRange(new object[] {
            "Array stack",
            "List stack",
            "Linkedlist stack"});
            this.SelectedIndex = 0;
            this.Location = aLocation;
            this.Size = aSize;

            this.Font = new Font("Verdana", aFontSize, FontStyle.Regular);
            this.ForeColor = Color.Black;

            aForm.Controls.Add(this);
        }
    }
}
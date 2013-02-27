using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPCalculator.Components;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HPCalculator
{
    class Main
    {
        private Form1 _Form;
        private gGroupbox _HPCalculator, _StackChoice, _LastEvent, _StackDisplay;
        private gTextbox _Input;
        private gButton _Reset, _Operator, _Enter;
        private gCombobox _ComboboxStackChoice;
        private gListbox _ListboxLastEvent;
        private gLabel _LabelStackDisplay;
        private List<string> _LastEventItems = new List<string>();

        /// <summary>
        /// Constructer for Main.
        /// </summary>
        /// <param name="aForm"></param>
        public Main(Form1 aForm)
        {
            _Form = aForm;
            _LastEventItems.Add("Event1");
            _LastEventItems.Add("Event2");
            InitVisuals();
            ClickEvents();
        }

        /// <summary>
        /// Initializes the visuals for HPCalculator.
        /// </summary>
        private void InitVisuals()
        {
            _Input = new gTextbox(_Form, "Input", new Point(10, 30), new Size(240, 20), string.Empty, 10);

            new gButton(_Form, "Number7", new Point(35 + (0 * 30), 70 + (0 * 30)), "7", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number8", new Point(35 + (1 * 30), 70 + (0 * 30)), "8", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number9", new Point(35 + (2 * 30), 70 + (0 * 30)), "9", new Size(30, 30), Color.Black, 10, _Numbers_Click);

            new gButton(_Form, "Number4", new Point(35 + (0 * 30), 70 + (1 * 30)), "4", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number5", new Point(35 + (1 * 30), 70 + (1 * 30)), "5", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number6", new Point(35 + (2 * 30), 70 + (1 * 30)), "6", new Size(30, 30), Color.Black, 10, _Numbers_Click);

            new gButton(_Form, "Number7", new Point(35 + (0 * 30), 70 + (2 * 30)), "1", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number8", new Point(35 + (1 * 30), 70 + (2 * 30)), "2", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            new gButton(_Form, "Number9", new Point(35 + (2 * 30), 70 + (2 * 30)), "3", new Size(30, 30), Color.Black, 10, _Numbers_Click);

            new gButton(_Form, "Number0", new Point(35 + (0 * 30), 70 + (3 * 30)), "0", new Size(30, 30), Color.Black, 10, _Numbers_Click);
            _Reset = new gButton(_Form, "ResetC", new Point(35 + (1 * 30), 70 + (3 * 30)), "C", new Size(30, 30), Color.Black, 10);

            _Operator = new gButton(_Form, "Operator+", new Point(35 + (4 * 30), 70 + (0 * 30)), "+", new Size(30, 30), Color.Red, 10);
            _Operator = new gButton(_Form, "Operator-", new Point(35 + (5 * 30), 70 + (0 * 30)), "-", new Size(30, 30), Color.Red, 10);
            _Operator = new gButton(_Form, "Operatorx", new Point(35 + (4 * 30), 70 + (1 * 30)), "x", new Size(30, 30), Color.Red, 10);
            _Operator = new gButton(_Form, "Operator/", new Point(35 + (5 * 30), 70 + (1 * 30)), "/", new Size(30, 30), Color.Red, 10);

            _Enter = new gButton(_Form, "Enter", new Point(35 + (4 * 30), 70 + (3 * 30)), "Enter", new Size(60, 30), Color.Black, 10);

            _ComboboxStackChoice = new gCombobox(_Form, "ComboboxStackChoice", new Point(10, 240), new Size(240, 30), 10);

            _ListboxLastEvent = new gListbox(_Form, "ListboxLastEvent", new Point(270, 25), new Size(170, 50), _LastEventItems, 10);

            _LabelStackDisplay = new gLabel(_Form, "LabelStackDisplay", new Point(275, 100), new Size(160, 150), "a", 10);

            _HPCalculator = new gGroupbox(_Form, new Point(5, 5), "HP Calculator:", new Size(250, 210), 8);
            _StackChoice = new gGroupbox(_Form, new Point(5, 220), "Stack Choice:", new Size(250, 50), 8);
            _StackDisplay = new gGroupbox(_Form, new Point(270, 80), "Stackdisplay:", new Size(170, 180), 8);
            _LastEvent = new gGroupbox(_Form, new Point(260, 5), "Last event:", new Size(190, 260), 8);
        }

        /// <summary>
        /// Checks for Clicks.
        /// </summary>
        private void ClickEvents()
        {
            _Reset.Click += new EventHandler(_Reset_Click);
            _Operator.Click += new EventHandler(_Operator_Click);
            _Enter.Click += new EventHandler(_Enter_Click);
        }


        private void _Enter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter is clicked.");
        }

        private void _Operator_Click(object sender, EventArgs e)
        {
            _Input.Text += _Operator.Text;
            MessageBox.Show("Operator is clicked.");
        }

        private void _Reset_Click(object sender, EventArgs e)
        {
            _Input.Text = string.Empty;
            MessageBox.Show("C is clicked.");
        }

        private void _Numbers_Click(Object sender, EventArgs e)
        {
            gButton gT = sender as gButton;
            if (gT != null)
            {
                _Input.Text += gT.Text;
                //MessageBox.Show("Number is clicked.");
            }
        }
    }
}

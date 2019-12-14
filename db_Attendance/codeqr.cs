using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BarcodeTest
{
    public partial class Form1 : Form
    {
        private Dictionary <TextBox, TextBox> TextBoxOrder = new Dictionary <TextBox, TextBox>();

        public BarcodeInputForm()
        {
            InitializeComponent();

            TextBoxOrder.Add(BarcodeInput1, BarcodeInput2);
            TextBoxOrder.Add(BarcodeInput2, BarcodeInput3);
            TextBoxOrder.Add(BarcodeInput3, BarcodeInput1);

            BarcodeInput1.Tag = 1;
            BarcodeInput2.Tag = 2;
            BarcodeInput3.Tag = 3;

            BarcodeInput1.KeyDown += BarcodeInputKeyDown;
            BarcodeInput2.KeyDown += BarcodeInputKeyDown;
            BarcodeInput3.KeyDown += BarcodeInputKeyDown;

            BarcodeInput1.Leave += BarcodeInputLeave;
            BarcodeInput2.Leave += BarcodeInputLeave;
            BarcodeInput3.Leave += BarcodeInputLeave;
        }

        private void BarcodeInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl.GetType() == typeof(TextBox))
            {
                TextBox nextTextBox;
                if(TextBoxOrder.TryGetValue((TextBox)ActiveControl, out nextTextBox))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    nextTextBox.Focus();
                }
            }
        }

        private void BarcodeInputLeave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.Tag.GetType() == typeof(int))
                {
                    BarcodeScanned(textBox.Text, (int)textBox.Tag);
                }
            }
        }

        private void BarcodeScanned(string barcode, int order)
        {
            DemoLabel.Text = order.ToString() + ": " + barcode;
        }
    }
}
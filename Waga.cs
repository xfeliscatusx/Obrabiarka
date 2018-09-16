using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obrabiarka
{
    public delegate void WagaAdd();

    public partial class Waga : MetroFramework.Forms.MetroForm
    {
        public event WagaAdd eventList;
        string TempNodeText;
        public Waga()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TempNodeText = "";
            if (eventList != null)
            {
                eventList();
            }
            this.Hide();
        }
        public string returnValue()
        {
            TempNodeText = textBox1.Text;
            return TempNodeText;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TempNodeText = textBox1.Text;
            int varunek;
            int.TryParse(TempNodeText, out varunek);

            if (varunek > 0 && varunek < 6)
            {
                TempNodeText = varunek.ToString();
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
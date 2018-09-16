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
    public delegate void Kryteria22();

    public partial class Kryteria2 : MetroFramework.Forms.MetroForm
    {
        public event Kryteria22 eventList;
        string dl;
        string sr;
        public Kryteria2()
        {
            InitializeComponent();
        }     
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (eventList != null)
            {
                eventList();
            }
            this.Hide();
        }
        public string returnValueSR()
        {
            sr = textBox1.Text;
            return sr;
        }
        public string returnValueDL()
        {
            dl = textBox2.Text;
            return dl;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
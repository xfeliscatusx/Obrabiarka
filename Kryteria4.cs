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
    public delegate void Kryteria6();

    public partial class Kryteria4 : MetroFramework.Forms.MetroForm
    {
        public event Kryteria6 eventList;
        string X;
        string Y;
        string Z;
        string f;

        public Kryteria4()
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
        public string returnValueX()
        {
            X = textBox1.Text;
            return X;
        }
        public string returnValueY()
        {
            Y = textBox3.Text;
            return Y;
        }
        public string returnValueZ()
        {
            Z = textBox4.Text;
            return Z;
        }
        public string returnValuef()
        {
            f = textBox4.Text;
            return f;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
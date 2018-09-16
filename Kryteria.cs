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
    public delegate void Kryteria1();

    public partial class Kryteria : MetroFramework.Forms.MetroForm
    {
        public event Kryteria1 eventList;
        string X;
        string Y;
        string Z;
        public Kryteria()
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
            Y = textBox2.Text;
            return Y;
        }
        public string returnValueZ()
        {
            Z = textBox3.Text;
            return Z;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
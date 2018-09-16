using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace Obrabiarka
{
    public delegate void AnchorageAdd();

    public partial class Dodaj_zamocowanie : MetroFramework.Forms.MetroForm
    {
        public event AnchorageAdd eventList2;
        public List<string> anchorage = new List<string>();
        public Dodaj_zamocowanie()
        {
            InitializeComponent();
        }
        private void Dodaj_zamocowanie_Load(object sender, EventArgs e)
        {
            this.checkedListBox1.CheckOnClick = true;
            checkedListBox1.Items.Insert(0, "zamocowanie 1");
            checkedListBox1.Items.Insert(1, "zamocowanie 2");
        }        
        public List<string> addAnchorageToList()
        {
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                anchorage.Add(item.ToString());
            }
            return anchorage;
        }      
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (eventList2 != null)
            {
                eventList2();
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
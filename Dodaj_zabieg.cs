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
using System.Data.SqlClient;

namespace Obrabiarka
{
    public delegate void TreatmentAdd();
    public partial class Dodaj_zabieg : MetroFramework.Forms.MetroForm
    {
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        public event TreatmentAdd eventList3;
        public List<string> treatment = new List<string>();
        public List<string> operations = new List<string>();

        public Dodaj_zabieg()
        {
            InitializeComponent();
        }
        private void Dodaj_zabieg_Load(object sender, EventArgs e)
        {
            installOperation();
        }
        private void installOperation()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = "select [dbo].[Zabiegi].nazwa_zabiegu FROM [Zabiegi] ";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    checkedListBox1.Items.Add(row[0].ToString());
                }
            }
        }
        public List<string> addTreatmentToList()
        {
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                treatment.Add(item.ToString());
            }
            return treatment;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (eventList3 != null)
            {
                eventList3();
            }
        }
    }
}
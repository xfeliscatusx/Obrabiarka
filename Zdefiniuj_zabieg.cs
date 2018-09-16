using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework;


namespace Obrabiarka
{
    public partial class Zdefiniuj_zabieg : MetroFramework.Forms.MetroForm
    {
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        public Zdefiniuj_zabieg()
        {
            InitializeComponent();
        }

        private void Zdefiniuj_zabieg_Load(object sender, EventArgs e)
        {

          
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string concatenateInsert()
        {
            string query = "";
            // addOperationToList();
            query = string.Format("insert into[dbo].[Zabiegi] (nazwa_zabiegu, wiertła, frezy, [narzędzia tokarskie], glowna) Values('{0}', '{1}', '{2}', '{3}', '{4}')", metroTextBox1.Text, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked,  checkBox1.Checked);

            return query;
        }
        private void insertMethod()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = concatenateInsert();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            insertMethod();
            MessageBox.Show("Zabieg została dodana do bazy danych");


        }
    }
}

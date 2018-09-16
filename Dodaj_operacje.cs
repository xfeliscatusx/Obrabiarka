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
    public delegate void OperationAdd();
    public partial class Dodaj_operacje : MetroFramework.Forms.MetroForm
    {
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        public event OperationAdd eventList;
        public List<string> operations = new List<string>();
        public Dodaj_operacje()
        {
            InitializeComponent();
        }
        private void Dodaj_operacje_Load(object sender, EventArgs e)
        {
            installOperation();
        }
        private void installOperation()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = "select [dbo].[Operacje].nazwa_operacji FROM [Operacje] ";
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
        public List<string> addOperationToList()
        {
            operations.Clear();
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                operations.Add(item.ToString());
            }
            return operations;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (eventList != null)
            {
                eventList();
            }
        }
    }
}
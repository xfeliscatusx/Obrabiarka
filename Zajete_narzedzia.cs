using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace Obrabiarka
{
    public partial class Zajete_narzedzia : MetroFramework.Forms.MetroForm
    {
        List<string> allTools = new List<string>(); /*{ "Tokarki karuzelowe", "Tokarki poziome", "Tokarki XZ", "Tokarki XZC z napedzanym narzedziem", "Frezarki 3 osiowe", "Frezarki 4 osiowe z napedzanym narzedziem", "Frezarki 5 osiowe", "Wiertarki reczne", "Wiertarki CNC", "Szlifierki bezklowe", "Szlifierki klowe" };*/
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        List<string> ReservedTools = new List<string>();
        List<string> idTools = new List<string>();
        List<string> nameReservedTools = new List<string>();
        string message = "";
        public Zajete_narzedzia()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getAllMachineFromData(getAll());
            installDataGridMachine(concatenateQueryTools());
        }
        public string getAll()
        {
            string cmd = "Select * From [dbo].[RodzajeNarzedzi]";
            return cmd;
        }
        public string concatenateQueryUpdate()
        {
            string query = "";
            saveClickedList();
            List<string> lista = allTools;
            List<string> reserved = ReservedTools;
            List<string> id = idTools;
            for (int i = 0; i < reserved.Count; i++)
            {
                query += "Update " + "[" + reserved.ElementAt(i).ToString() + "] SET [" + reserved.ElementAt(i).ToString() + "]." + "[Rezerwuj]='false'" + " Where " + "[" + reserved.ElementAt(i).ToString() + "].[id]=" + "'" + id.ElementAt(i).ToString() + "' ";
            }
            return query;
        }
        private void installDataGridMachine(string CmdString)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(CmdString, sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable("Nazwa narzędzia", "Rezerwuj");
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView1.AllowUserToAddRows = false;
            }
        }
        private void getAllMachineFromData(string CmdString)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(CmdString, sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable("rodzaj_narzedzia");
                sqlDa.Fill(dtbl);

                allTools = dtbl.AsEnumerable()
                           .Select(r => r.Field<string>("rodzaj_narzedzia"))
                           .ToList();
            }
        }
        private void doUnReservationOfTools()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConString))
                {
                    sqlCon.Open();
                    string CmdString = concatenateQueryUpdate();
                    cmd = new SqlCommand(CmdString, sqlCon);
                    sqlDa = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nie zwolniono obrabiarki", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string concatenateQueryTools()
        {
            string query = "";
            string unia = "UNION";
            var lista = allTools;
            foreach (var i in lista)
            {
                query += "SELECT '" + i.ToString() + "' AS [table_name] " + ",[" + i.ToString() + "].[" + "Id" + "] , " + "[" + i.ToString() + "].[" + "Nazwa narzędzia" + "]," + "[" + i.ToString() + "].[Rezerwuj] FROM [dbo].[" + i.ToString() + "] Where [Rezerwuj]='True' " + unia + " ";
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void messageFunction()
        {
            message = "";
            foreach (var i in nameReservedTools)
            {
                message += i.ToString() + "\r\n";
            }
            message += "\r\n";
        }
        private void saveClickedList()
        {
            try
            {
                DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

                foreach (DataRow row in changes.Rows)
                {
                    idTools.Add(row[1].ToString());
                    ReservedTools.Add(row[0].ToString());
                    nameReservedTools.Add(row[2].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie udalo sie pobrac wybranych obrabiarek");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doUnReservationOfTools();
            messageFunction();
            MessageBox.Show("Zwolniono:\r\n" + message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReservedTools.Clear();
            idTools.Clear();
            nameReservedTools.Clear();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            getAllMachineFromData(getAll());
            installDataGridMachine(concatenateQueryTools());
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zwolniono", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
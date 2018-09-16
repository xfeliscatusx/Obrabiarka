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
    public partial class Zajete_obrabiarki : MetroFramework.Forms.MetroForm
    {
        List<string> allMachine = new List<string>(); /*{ "Tokarki karuzelowe", "Tokarki poziome", "Tokarki XZ", "Tokarki XZC z napedzanym narzedziem", "Frezarki 3 osiowe", "Frezarki 4 osiowe z napedzanym narzedziem", "Frezarki 5 osiowe", "Wiertarki reczne", "Wiertarki CNC", "Szlifierki bezklowe", "Szlifierki klowe" };*/
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        List<string> ReservedMachine = new List<string>();
        List<string> idMachine = new List<string>();
        List<string> nameReservedMachine = new List<string>();
        string message = "";
        public Zajete_obrabiarki()
        {
            InitializeComponent();
        }
        private void ZajeteObrabiarki_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            getAllMachineFromData(getAll());
            installDataGridMachine(concatenateQueryMachine());
        }
        private string concatenateQueryUpdate()
        {
            string query = "";
            saveClickedList();
            List<string> lista =allMachine;
            List<string> reserved = ReservedMachine;
            List<string> id = idMachine;
            for (int i = 0; i < reserved.Count; i++)
            {
                query += "Update " + "[" + reserved.ElementAt(i).ToString() + "] SET [" + reserved.ElementAt(i).ToString() + "]." + "[Rezerwuj]='false'" + " Where " + "[" + reserved.ElementAt(i).ToString() + "].[id]=" + "'" + id.ElementAt(i).ToString() + "' ";
            }
            return query;
        }
        private void doUnReservationOfMachines()
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
        public string getAll()
        {
            string cmd = "Select * From [dbo].[RodzajeObrabiarek]";
            return cmd;
        }
        public string concatenateQueryMachine()
        {
            string query = "";
            string unia = "UNION";
            var lista = allMachine;
            foreach (var i in lista)
            {
                query += "SELECT '" + i.ToString() + "' AS [table_name] " + ",[" + i.ToString() + "].[" + "Id" + "] , " + "[" + i.ToString() + "].[" + "Nazwa" + "]," + "[" + i.ToString() + "].[Rezerwuj] FROM [dbo].[" + i.ToString() + "] Where [Rezerwuj]='True' " + unia + " ";
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void installDataGridMachine(string CmdString)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable("Nazwa", "Rezerwuj");
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
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable("rodzaj_obrabiarki");
                sqlDa.Fill(dtbl);
                allMachine = dtbl.AsEnumerable()
                           .Select(r => r.Field<string>("rodzaj_obrabiarki"))
                           .ToList();
            }
        }
        private void messageFunction()
        {
            message = "";
            foreach (var i in nameReservedMachine)
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
                    idMachine.Add(row[1].ToString());
                    ReservedMachine.Add(row[0].ToString());
                    nameReservedMachine.Add(row[2].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie udalo sie pobrac wybranych obrabiarek");
            }

        }   
        private void button1_Click(object sender, EventArgs e)
        {
            doUnReservationOfMachines();
            messageFunction();
            MessageBox.Show("Zwolniono:\r\n" + message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReservedMachine.Clear();
            idMachine.Clear();
            nameReservedMachine.Clear();
        }     
        private void metroButton3_Click(object sender, EventArgs e)
        {
            getAllMachineFromData(getAll());
            installDataGridMachine(concatenateQueryMachine());
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            doUnReservationOfMachines();
            messageFunction();
            MessageBox.Show("Zwolniono:\r\n" + message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReservedMachine.Clear();
            idMachine.Clear();
            nameReservedMachine.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
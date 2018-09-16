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

namespace Obrabiarka
{
    public partial class Wyswietl_narzedzia : MetroFramework.Forms.MetroForm
    {

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        int node_number, waga, x, y, z;
        string node_name, rodzaj_obrabiarki;
        List<string> firstOptionWithDouble = new List<string>(); // opcja wybrana z dubli
        string secondOptionWithDouble; // opcja wybrana z dubli bez dubli
        string queryNOduble = "";
        string message;
        List<string> zdubloaneZbazy = new List<string>();
        string zdublowaneWynik;
        List<string> NIEzdubloaneZbazy = new List<string>();
        string NIEzdublowaneWynik;
        string slectt = "";
        string from = "";
        string where = "";
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY0 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY1 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY2 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY3 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY4 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY5 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY6 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY7 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY8 = new List<Tuple<int, string, string, int, int, int, int>>();
        List<Tuple<int, string, string, int, int, int, int>> COPYCOPY9 = new List<Tuple<int, string, string, int, int, int, int>>();
        string Copy0Value, Copy1Value, Copy2Value, Copy3Value, Copy4Value, Copy5Value, Copy6Value, Copy7Value, Copy8Value, Copy9Value;
        List<string> copyvaluewynik = new List<string>();
        List<string> sklejka = new List<string>();
        List<string> copynamegroup = new List<string>();
        List<string> copynameTable = new List<string>();
        List<string> nameTable = new List<string>();
        List<string> reservedMachine = new List<string>();
        List<string> machineFromDatabase = new List<string>();
        List<string> listWithDoubleDistinct = new List<string>();
        Tuple<int, string, string, int, int, int, int> FULLTUPLE = Tuple.Create(0, "", "", 0, 0, 0, 0);
        List<Tuple<int, string, string, int, int, int, int>> FULLTUPLEtoDB = new List<Tuple<int, string, string, int, int, int, int>>();
        Tuple<int, string, string, int, int, int, int> firstOption = Tuple.Create(0, "", "", 0, 0, 0, 0);
        List<Tuple<int, string, string, int, int, int, int>> firstOptionList = new List<Tuple<int, string, string, int, int, int, int>>();
        List<List<Tuple<int, string, string, int, int, int, int>>> listByNumberNode = new List<List<Tuple<int, string, string, int, int, int, int>>>();
        List<string> weightMachine = new List<string>();
        List<string> operationName = new List<string>();
        List<string> rodzajobrabiarki = new List<string>();
        int orginialIdOfChild;
        private Proces_technologiczny _parent;
                
        Proces_technologiczny aaa = new Proces_technologiczny();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string ID = comboBox1.SelectedValue.ToString();
            if (selected == "Wszystkie")
            {
                installDataGridMachine(dataGridView1);
            }
            if (selected != "Wybierz" && selected != "Wszystkie")
            {
                installDataGridMachineByType(selected,dataGridView1);
            }
        }
        public string concatenateQueryMachine(string selected)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzedzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            string query = "";
            foreach (var i in FULLTUPLEtoDB)
            {

                query += string.Format("select [{0}].[Nazwa narzędzia]," +
                     " [{0}].[d1], [{0}].[l], [{0}].[f] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where d1={1} AND l={2} AND f={3} AND Rezerwuj='false' UNION ", selected, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        public string concatenateQueryMachine()
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzędzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");

            string query = "";                      

            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa narzędzia]," +
                     " [{0}].[d1], [{0}].[l], [{0}].[f] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where d1={1} AND l={2} AND f={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void installDataGridMachine(DataGridView data)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzędzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");

            List<string> operacje = new List<string>();
            foreach (var i in FULLTUPLEtoDB)
            {
                operacje.Add(i.Item2);
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = concatenateQueryMachine();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable("Nazwa", "Rezerwuj");

                sqlDa.Fill(dtbl);

                data.DataSource = dtbl;
                int i = 0;
            }
        }
        private void installDataGridMachineByType(string selected, DataGridView data)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzędzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            List<string> operacje = new List<string>();
            foreach (var i in FULLTUPLEtoDB)
            {
                operacje.Add(i.Item2);
            }
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string CmdString = concatenateQueryMachine(selected);
                    cmd = new SqlCommand(CmdString, sqlCon);
                    sqlDa = new SqlDataAdapter(cmd);
                    dtbl = new DataTable("Nazwa", "Rezerwuj");

                    sqlDa.Fill(dtbl);

                    data.DataSource = dtbl;
                    int i = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Kontynuuj", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox3.Text;
            string ID = comboBox3.SelectedValue.ToString();
            if (selected == "Wszystkie")
            {
                installDataGridMachine(dataGridView2);
            }
            if (selected != "Wybierz" && selected != "Wszystkie")
            {
                installDataGridMachineByType(selected,dataGridView2);
            }
        }
        public Wyswietl_narzedzia(Proces_technologiczny parent)
        {
            InitializeComponent();
            _parent = parent; // assign the ref of the parent
            var lista = _parent.numberofChildTreeView;
            panel1.Hide();
            panel2.Hide();
                    }

        private void Wyswietl_narzedzia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'contactDBDataSet.Obrabiarki' table. You can move, or remove it, as needed.
            this.obrabiarkiTableAdapter.Fill(this.contactDBDataSet.Obrabiarki);

        }
        void numberNodeChild2()
        {
            var wynik=aaa.numberofChild();
        }
        public void getListForWeight(Proces_technologiczny _parent)
        {
             orginialIdOfChild = _parent.numberofChild();


            FULLTUPLEtoDB.Clear();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select  node_number, nazwa_zabiegu, rodzaj_narzedzia,waga, d1, l,f from [dbo].[ZdefiniowaneNarzedzia]";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    int.TryParse(row[0].ToString(), out node_number);
                    node_name = row[1].ToString();
                    rodzaj_obrabiarki = row[2].ToString();
                    int.TryParse(row[3].ToString(), out waga);
                    int.TryParse(row[4].ToString(), out x);
                    int.TryParse(row[5].ToString(), out y);
                    int.TryParse(row[6].ToString(), out z);
                    FULLTUPLE = new Tuple<int, string, string, int, int, int, int>(node_number, node_name, rodzaj_obrabiarki, waga, x, y, z);
                    FULLTUPLEtoDB.Add(FULLTUPLE);
                }
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzędzia tokarskie");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertla");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzedzia tokarskie");
            }
            generateTupleByKind();
        }
        public void generateTupleByKind()
        {
            operationName.Clear();
            weightMachine.Clear();
            rodzajobrabiarki.Clear();
            List<string> hhh = new List<string>();
            string operation = null;
            string bbb = "";
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzędzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            listByNumberNode = FULLTUPLEtoDB.GroupBy(x => x.Item1).Select(x => x.OrderByDescending(y => y.Item4).ToList()).ToList();
            int p = 0;
            foreach (List<Tuple<int, string, string, int, int, int, int>> item in listByNumberNode)
            {
                foreach (Tuple<int, string, string, int, int, int, int> element in item)
                {
                    if(element.Item1== orginialIdOfChild)
                    {
                        hhh.Add(getWeightName_Node(weightQuery(element.Item3, element.Item5, element.Item6, element.Item7)));
                        operation = element.Item2;
                        bbb = element.Item3;
                        rodzajobrabiarki.Add(bbb);
                    }


                }
                weightMachine.Add(hhh.OfType<string>().FirstOrDefault());
                hhh.Clear();
                operationName.Add(operation);
                p++;
            }
            compareOperationAndNames();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string weightQuery(string rodzaj_obrabiarki, int X, int Y, int Z)
        {
            string query = "";
            query = string.Format("select [{0}].[Nazwa narzędzia]," +
                        " [{0}].[d1], [{0}].[l] ,[{0}].[f], [{0}].[Rezerwuj] From [{0}] " +
                        "Where d1={1} AND l={2} AND f={3} AND Rezerwuj='false'", rodzaj_obrabiarki, X, Y, Z);
            return query;
        }
        private string getWeightName_Node(string query)
        {
            List<string> temp = new List<string>();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                cmd = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    temp.Add(row[0].ToString());
                }
            }
            return temp.FirstOrDefault();
        }
        private Dictionary<string, string> compareOperationAndNames()
        {
            Dictionary<string, string> machine_operation = new Dictionary<string, string>();

                machine_operation.Add(operationName.OfType<string>().FirstOrDefault(), weightMachine.OfType<string>().FirstOrDefault());
            return machine_operation;
        }
        private string MessageWagi()
        {
            message = "";
            message = "Dobrane narzędzie :\r\n";
            foreach (var i in compareOperationAndNames())
            {
                message += string.Format("{0}\r\n{1}\r\n", i.Key, i.Value);
            }
            return message;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void wagiReservation(string query)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = query;
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        }
        public string queryWagi(string rodzaj, string machineName)
        {
            string query = "";
            query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa narzędzia] like N'%{1}%' ", rodzaj, machineName);
            return query;
        }
        private void metroButton6_Click(object sender, EventArgs e)
        {
            getListForWeight(_parent);
            DialogResult result = MessageBox.Show(MessageWagi(), "Czy przypisać do procesu?", MessageBoxButtons.OKCancel);
                var temp = compareOperationAndNames();
                switch (result)
                {
                    case DialogResult.OK:
                        {
                        installCombobox3(comboBox1);
                        panel1.Show();
                        panel2.Hide();
                        this.Text = "[Przypisz obrabiarki do procesu]";        
                            for (int i = 0; i < rodzajobrabiarki.Count; i++)
                            {
                                foreach (var k in temp)
                                {
                                    if (k.Value == null)
                                        wagiReservation(queryWagi(rodzajobrabiarki.ElementAt(i), "brak obrabiarek w bazie o podanych kryteriach"));
                                    else
                                        wagiReservation(queryWagi(rodzajobrabiarki.ElementAt(i), k.Value));
                                }
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                        installCombobox3(comboBox3);
                        this.Text = "[Zdefiniuj ręcznie]";
                        panel2.Show();
                        panel1.Hide();
                        break;
                        
                }
            }

        }
        public void installCombobox3(ComboBox com)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                string CmdString =string.Format("select DISTINCT rodzaj_narzedzia from ZdefiniowaneNarzedzia Where  " +
                    "[node_number]={0}", orginialIdOfChild);
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DataRow row = dtbl.NewRow();
                row["rodzaj_narzedzia"] = "Wybierz";
                dtbl.Rows.InsertAt(row, 0);
                row = dtbl.NewRow();
                row["rodzaj_narzedzia"] = "Wszystkie";
                dtbl.Rows.InsertAt(row, 1);
                for (int i = dtbl.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtbl.Rows[i];
                    if (dr["rodzaj_narzedzia"] == "Wiertła")
                        dr.Delete();
                    if (dr["rodzaj_narzedzia"] == "Frezy")
                        dr.Delete();
                    if (dr["rodzaj_narzedzia"] == "Narzędzia tokarskie")
                        dr.Delete();
                    if (dr["rodzaj_narzedzia"] == "Wytaczaki tokarskie")
                        dr.Delete();
                }
                com.DataSource = dtbl;
                com.DisplayMember = "rodzaj_narzedzia";
                com.SelectedItem = "Wybierz";
            }
        }


























        private void installDataGridMachineByType3(string selected)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
            List<string> operacje = new List<string>();
            foreach (var i in FULLTUPLEtoDB)
            {
                operacje.Add(i.Item2);
            }
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string CmdString = concatenateQueryMachine3(selected);
                    cmd = new SqlCommand(CmdString, sqlCon);
                    sqlDa = new SqlDataAdapter(cmd);
                    dtbl = new DataTable("Nazwa", "Rezerwuj");
                    sqlDa.Fill(dtbl);
                    dataGridView2.DataSource = dtbl;
                    int i = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Kontynuuj", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void installDataGridMachine3()
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzedzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            List<string> operacje = new List<string>();
            foreach (var i in FULLTUPLEtoDB)
            {
                operacje.Add(i.Item2);
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = concatenateQueryMachine3();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable("Nazwa", "Rezerwuj");

                sqlDa.Fill(dtbl);

                dataGridView2.DataSource = dtbl;
                int i = 0;
            }
        }
        public string concatenateQueryMachine3(string selected)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzedzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            string query = "";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            foreach (var i in weightMachine)
            {
                if (i != null)
                {
                    query += string.Format("SELECT [{0}].[Nazwa narzedzia], [{0}].[d1], [{0}].[l], [{0}].[f] , [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa narzedzia] like '%{1}%'  UNION ", selected, i.ToString());
                }
            }
            foreach (var i in sklejka)
            {
                if (i != null)
                {
                    query += string.Format("SELECT [{0}].[Nazwa narzedzia], [{0}].[d1], [{0}].[l], [{0}].[f] , [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa] like '%{1}%'  UNION ", selected, i.ToString());
                }
            }
            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa narzedzia]," +
                     " [{0}].[d1], [{0}].[l], [{0}].[f] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", selected, i.Item5, i.Item6, i.Item7);
            }

            query = query.Remove(query.Length - 6);
            return query;
        }
        public string concatenateQueryMachine3()
        {
            getAllKindOfMachineFromDataBase();
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertła");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezy");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Narzedzia tokarskie");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wytaczaki tokarskie");
            string query = "";

            //    fullListRodzajow = fullListRodzajow.Distinct().ToList();     
            foreach (var i in weightMachine)
            {
                if (i != null)
                {
                    foreach (var j in machineFromDatabase)
                    {
                        query += string.Format("SELECT [{0}].[Nazwa narzedzia], [{0}].[d1], [{0}].[l] , [{0}].[f], [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa narzedzia] like '%{1}%'  UNION ", j.ToString(), i.ToString());
                    }
                }
            }
            foreach (var i in sklejka)
            {
                if (i != null)
                {
                    foreach (var j in machineFromDatabase)
                    {
                        query += string.Format("SELECT [{0}].[Nazwa narzedzia], [{0}].[d1], [{0}].[l] , [{0}].[f], [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa narzedzia] like '%{1}%'  UNION ", j.ToString(), i.ToString());
                    }
                }
            }
            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa narzedzia]," +
                     " [{0}].[d1], [{0}].[l], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        public void getAllKindOfMachineFromDataBase()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "";
                sqlCon.Open();
                string CmdString = "Select rodzaj_narzedzia from RodzajeNarzedzi";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    machineFromDatabase.Add(row[0].ToString());
                }
            }
        }
    }
}

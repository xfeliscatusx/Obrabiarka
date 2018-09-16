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
using System.Linq;
using System.Data.Entity;

namespace Obrabiarka
{
    public partial class Wyswietl_obrabiarki : MetroFramework.Forms.MetroForm
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
        public Wyswietl_obrabiarki()
        {
            InitializeComponent();
            populateCombobx();
            metroButton5.Enabled = false;
            metroButton6.Enabled = false;
            getList();
            panel1.Hide();
            panel2.Hide();
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        public void getListForWeight()
        {
            FULLTUPLEtoDB.Clear();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select  node_number, node_name, rodzaj_obrabiarki,waga, X, Y,Z from [dbo].[ZdefiniowaneObrabiarki]";
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
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
                generateTupleByKind();
            }
        }
        public void generateTupleByKind()
        {
            operationName.Clear();
            weightMachine.Clear();
            rodzajobrabiarki.Clear();
            List<string> hhh = new List<string>();
            string operation = "";
            string bbb = "";

            listByNumberNode = FULLTUPLEtoDB.GroupBy(x => x.Item1).Select(x => x.OrderByDescending(y => y.Item4).ToList()).ToList();
            int p = 0;
            foreach (List<Tuple<int, string, string, int, int, int, int>> item in listByNumberNode)
            {
                foreach (Tuple<int, string, string, int, int, int, int> element in item)
                {
                    hhh.Add(getWeightName_Node(weightQuery(element.Item3, element.Item5, element.Item6, element.Item7)));
                    operation = element.Item2;
                    bbb = element.Item3;
                    rodzajobrabiarki.Add(bbb);
                    
                }
                weightMachine.Add(hhh.OfType<string>().FirstOrDefault());
                hhh.Clear();
                operationName.Add(operation);
                p++;
            }
            compareOperationAndNames();
        }
        private string weightQuery(string rodzaj_obrabiarki, int X, int Y, int Z)
        {
            string query = "";
            query = string.Format("select [{0}].[Nazwa]," +
                        " [{0}].[X], [{0}].[Z] ,[{0}].[Y], [{0}].[Rezerwuj] From [{0}] " +
                        "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false'", rodzaj_obrabiarki, X, Y, Z);
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
            for (int i = 0; i < operationName.Count; i++)
            {
                machine_operation.Add(operationName[i], weightMachine[i]);
            }
            return machine_operation;
        }
        private string MessageWagiForOne()
        {
            message = "";
            message = "Dobrane obrabiarki :\r\n";
            foreach (var i in compareOperationAndNames())
            {
                if(i.Key==selectedCombobox)
                message += string.Format("{0}\r\n{1}\r\n", i.Key, i.Value);
            }
            return message;
        }
        private string MessageWagi()
        {
            message = "";
            message = "Dobrane obrabiarki :\r\n";
            foreach (var i in compareOperationAndNames())
            {
                message += string.Format("{0}\r\n{1}\r\n", i.Key, i.Value);
            }
            return message;
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
            query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ", rodzaj, machineName);
            return query;
        }
        string selectedCombobox;
        private void metroButton6_Click(object sender, EventArgs e)
        {
            getListForWeight();
            if (selectedCombobox == "Wszystkie")
            {
                DialogResult result = MessageBox.Show(MessageWagi(), "Czy przypisać do procesu?", MessageBoxButtons.OKCancel);
                var temp = compareOperationAndNames();
                switch (result)
                {
                    case DialogResult.OK:
                        {
                            this.Text = "[Przypisz obrabiarki do procesu]";
                            installCombobox3();
                            panel1.Hide();
                            panel2.Show();
                            label7.Hide();
                            for(int i = 0; i < rodzajobrabiarki.Count; i++)
                            {
                                foreach (var k in temp)
                                {
                                    if (k.Value == null)
                                    wagiReservation(queryWagi(rodzajobrabiarki.ElementAt(i), "brak obrabiarek w bazie o podanych kryteriach"));
                                    else
                                    wagiReservation(queryWagi(rodzajobrabiarki.ElementAt(i),k.Value));
                                }
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            installCombobox1();
                            this.Text = "[Zdefiniuj ręcznie]";
                            panel2.Hide();
                            panel1.Show();
                            metroButton4.Hide();
                            break;
                        }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(MessageWagiForOne(), "Czy przypisać do procesu?", MessageBoxButtons.OKCancel);
                var temp = compareOperationAndNames();
                switch (result)
                {
                    case DialogResult.OK:
                        {
                            this.Text = "[Przypisz obrabiarki do procesu]";
                            panel2.Hide();
                            panel1.Hide();
                            label7.Hide();
                            int x = 0;
                            for (int i = 0; i < rodzajobrabiarki.Count; i++)
                            {
                                foreach (var k in temp)
                                {
                                    if (selectedCombobox == k.Key)
                                    {
                                        wagiReservation(queryWagi(rodzajobrabiarki.ElementAt(i), k.Value));
                                    }
                                }
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this.Text = "[Zdefiniuj ręcznie]";
                            panel1.Hide();
                            panel2.Hide();

                            metroButton4.Hide();
                            break;
                        }
                }
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCombobox = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);

            if (selectedCombobox == "Wszystkie")
            {
                metroButton5.Enabled = true;
                metroButton6.Enabled = true;
            }
            if (selectedCombobox == "Wybierz")
            {
                metroButton5.Enabled = false;
                metroButton6.Enabled = false;
            }
            if (selectedCombobox != "Wybierz" && selectedCombobox != "Wszystkie")
            {
                metroButton5.Enabled = false;
                metroButton6.Enabled = true;
            }
        }












        public void getList()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select  node_number, node_name, rodzaj_obrabiarki,waga, X, Y,Z from [dbo].[ZdefiniowaneObrabiarki]";
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
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
                FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
                prepareKind();
            }
        }
        private void prepareKind()
        {
            List<string> listWithDouble = new List<string>(); ;// lista z powtórkami(rodzajami)
            int j = 0;
            //robimy liste z dublującymi sie rodzajami
            List<Tuple<int, string, string, int, int, int, int>> COPY = new List<Tuple<int, string, string, int, int, int, int>>();

            var resultList = FULLTUPLEtoDB.GroupBy(x => new { x.Item3 })
                     .Where(g => g.Count() > 1)
                     .SelectMany(g => g)
                     .ToList();
            COPY = FULLTUPLEtoDB.ToList();
            //wchodzimy gdy są duble
            if (resultList.Count != 0)
            {
                selectDuble();
                //wybiermy pierwszy lepszy
                var one = resultList.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
                //firstOptionWithDouble = one.Item3.ToString();
                //kasujemy te elementy w których byly double
                foreach (var k in resultList)
                {
                    listWithDouble.Add(k.Item2);
                }
                listWithDoubleDistinct = listWithDouble.GroupBy(car => car).Select(g => g.First()).ToList(); // listWithDoubleDistinct

                for (int i = 0; i < listWithDoubleDistinct.Count; i++)
                {

                    COPY.RemoveAll(x => x.Item2 == listWithDoubleDistinct.ElementAt(i));
                }

                int o = 0;

                foreach (var i in COPY)
                {
                    var ttt = COPY.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
                    if (i.Item1 == 0)
                    {
                        COPYCOPY0 = COPY.Where(x => x.Item1 == 0).ToList();
                        copytruple(COPYCOPY0, out Copy0Value);
                    }
                    if (i.Item1 == 1)
                    {
                        COPYCOPY1 = COPY.Where(x => x.Item1 == 1).ToList();
                        copytruple(COPYCOPY1, out Copy1Value);
                    }
                    if (i.Item1 == 2)
                    {
                        COPYCOPY2 = COPY.Where(x => x.Item1 == 2).ToList();
                        copytruple(COPYCOPY2, out Copy2Value);
                    }
                    if (i.Item1 == 3)
                    {
                        COPYCOPY3 = COPY.Where(x => x.Item1 == 3).ToList();
                        copytruple(COPYCOPY3, out Copy3Value);
                    }
                    if (i.Item1 == 4)
                    {
                        COPYCOPY4 = COPY.Where(x => x.Item1 == 4).ToList();
                        copytruple(COPYCOPY4, out Copy4Value);
                    }
                    if (i.Item1 == 5)
                    {
                        COPYCOPY5 = COPY.Where(x => x.Item1 == 5).ToList();
                        copytruple(COPYCOPY5, out Copy5Value);
                    }
                    if (i.Item1 == 6)
                    {
                        COPYCOPY6 = COPY.Where(x => x.Item1 == 6).ToList();
                        copytruple(COPYCOPY6, out Copy6Value);
                    }
                    if (i.Item1 == 7)
                    {
                        COPYCOPY7 = COPY.Where(x => x.Item1 == 7).ToList();
                        copytruple(COPYCOPY7, out Copy7Value);
                    }
                    if (i.Item1 == 8)
                    {
                        COPYCOPY8 = COPY.Where(x => x.Item1 == 8).ToList();
                        copytruple(COPYCOPY8, out Copy8Value);
                    }
                    if (i.Item1 == 9)
                    {
                        COPYCOPY8 = COPY.Where(x => x.Item1 == 9).ToList();
                        copytruple(COPYCOPY9, out Copy9Value);
                    }
                }
                COPY.RemoveAll(item => item.Item3 == "Frezarki");
                COPY.RemoveAll(item => item.Item3 == "Wiertarki");
                COPY.RemoveAll(item => item.Item3 == "Tokarki");
                foreach (var i in COPY)
                {
                    slectt += string.Format(" [{0}].[Nazwa], [{0}].[X], [{0}].[Z] , [{0}].[Y], ", i.Item3);
                    where += string.Format("[{0}].[X]<={1} AND [{0}].[Y]<={2} AND [{0}].[Z]<={3} AND ", i.Item3, i.Item5, i.Item6, i.Item7);
                }
                foreach (var i in COPY)
                {
                    from += string.Format(" [{0}],", i.Item3);
                }
                slectt = slectt.Remove(slectt.Length - 2);
                from = from.Remove(from.Length - 1);
                where = where.Remove(where.Length - 4);
                queryNOduble = string.Format("Select {0} FROM {1} WHERE {2}", slectt, from, where);
                selectNoDuble();
                var two = COPY.OrderBy(x => x.Item3).FirstOrDefault();
                secondOptionWithDouble = two.Item3.ToString();
            }
            else
            {
                listWithDoubleDistinct = listWithDouble.GroupBy(car => car).Select(g => g.First()).ToList(); // listWithDoubleDistinct

                for (int i = 0; i < listWithDoubleDistinct.Count; i++)
                {
                    COPY.RemoveAll(x => x.Item2 == listWithDoubleDistinct.ElementAt(i));
                }

                int o = 0;
                foreach (var i in COPY)
                {
                    var ttt = COPY.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
                    if (i.Item1 == 0)
                    {
                        COPYCOPY0 = COPY.Where(x => x.Item1 == 0).ToList();
                        copytruple(COPYCOPY0, out Copy0Value);
                    }
                    if (i.Item1 == 1)
                    {
                        COPYCOPY1 = COPY.Where(x => x.Item1 == 1).ToList();
                        copytruple(COPYCOPY1, out Copy1Value);
                    }
                    if (i.Item1 == 2)
                    {
                        COPYCOPY2 = COPY.Where(x => x.Item1 == 2).ToList();
                        copytruple(COPYCOPY2, out Copy2Value);
                    }
                    if (i.Item1 == 3)
                    {
                        COPYCOPY3 = COPY.Where(x => x.Item1 == 3).ToList();
                        copytruple(COPYCOPY3, out Copy3Value);
                    }
                    if (i.Item1 == 4)
                    {
                        COPYCOPY4 = COPY.Where(x => x.Item1 == 4).ToList();
                        copytruple(COPYCOPY4, out Copy4Value);
                    }
                    if (i.Item1 == 5)
                    {
                        COPYCOPY5 = COPY.Where(x => x.Item1 == 5).ToList();
                        copytruple(COPYCOPY5, out Copy5Value);
                    }
                    if (i.Item1 == 6)
                    {
                        COPYCOPY6 = COPY.Where(x => x.Item1 == 6).ToList();
                        copytruple(COPYCOPY6, out Copy6Value);
                    }
                    if (i.Item1 == 7)
                    {
                        COPYCOPY7 = COPY.Where(x => x.Item1 == 7).ToList();
                        copytruple(COPYCOPY7, out Copy7Value);
                    }
                    if (i.Item1 == 8)
                    {
                        COPYCOPY8 = COPY.Where(x => x.Item1 == 8).ToList();
                        copytruple(COPYCOPY8, out Copy8Value);
                    }
                    if (i.Item1 == 9)
                    {
                        COPYCOPY8 = COPY.Where(x => x.Item1 == 9).ToList();
                        copytruple(COPYCOPY9, out Copy9Value);
                    }
                }
                COPY.RemoveAll(item => item.Item3 == "Frezarki");
                COPY.RemoveAll(item => item.Item3 == "Wiertarki");
                COPY.RemoveAll(item => item.Item3 == "Tokarki");
                foreach (var i in COPY)
                {
                    slectt += string.Format(" [{0}].[Nazwa], [{0}].[X], [{0}].[Z], [{0}].[Y], ", i.Item3);
                    where += string.Format("[{0}].[X]<={1} AND [{0}].[Y]<={2} AND [{0}].[Z]<={3} AND ", i.Item3, i.Item5, i.Item6, i.Item7);
                }
                foreach (var i in COPY)
                {
                    from += string.Format(" [{0}],", i.Item3);
                }
                slectt = slectt.Remove(slectt.Length - 2);
                from = from.Remove(from.Length - 1);
                where = where.Remove(where.Length - 4);
                queryNOduble = string.Format("Select {0} FROM {1} WHERE {2}", slectt, from, where);
                selectNoDuble();
                var two = COPY.OrderBy(x => x.Item3).FirstOrDefault();
                secondOptionWithDouble = two.Item3.ToString();
            }
        }
        void copytruple(List<Tuple<int, string, string, int, int, int, int>> COPYCOPY, out string wynik)
        {
            List<string> ttttrrrr = new List<string>();
            COPYCOPY.RemoveAll(item => item.Item3 == "Frezarki");
            COPYCOPY.RemoveAll(item => item.Item3 == "Wiertarki");
            COPYCOPY.RemoveAll(item => item.Item3 == "Tokarki");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "";
                foreach (var i in COPYCOPY)
                {
                    query += string.Format("select [{0}].[Nazwa]," +
                        " [{0}].[X], [{0}].[Z], [{0}].[Y], [{0}].[Rezerwuj] From [{0}] Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
                    copynamegroup.Add(i.Item2.ToString());
                    copynameTable.Add(i.Item3.ToString());
                }
                query = query.Remove(query.Length - 6);

                sqlCon.Open();
                string CmdString = query;
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    ttttrrrr.Add(row[0].ToString());
                }
            }
            wynik = ttttrrrr.FirstOrDefault();
            copyvaluewynik.Add(wynik);
        }
        public string selectDubleQuery()
        {
            string query = "";
            var resultList = FULLTUPLEtoDB.GroupBy(x => new { x.Item3 })
                     .Where(g => g.Count() > 1)
                     .SelectMany(g => g)
                     .ToList();
            resultList.RemoveAll(item => item.Item3 == "Frezarki");
            resultList.RemoveAll(item => item.Item3 == "Wiertarki");
            resultList.RemoveAll(item => item.Item3 == "Tokarki");
            foreach (var i in resultList)
            {
                query += string.Format("select [{0}].[Nazwa]," +
                    " [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}] Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
                nameTable.Add(i.Item3.ToString());
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void selectNoDuble()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string CmdString = queryNOduble;
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                List<string> ids = new List<string>(dtbl.Rows.Count);
                foreach (DataRow row in dtbl.Rows)
                    ids.Add((string)row["Nazwa"]);
            }
            NIEzdublowaneWynik = NIEzdubloaneZbazy.FirstOrDefault();
        }
        private void selectDuble()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string CmdString = selectDubleQuery();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    zdubloaneZbazy.Add(row[0].ToString());
                }
            }
            zdublowaneWynik = zdubloaneZbazy.FirstOrDefault();
        }
        public void populateCombobx()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select DISTINCT node_number,node_name from ZdefiniowaneObrabiarki ";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DataRow row = dtbl.NewRow();
                row["node_name"] = "Wybierz";
                dtbl.Rows.InsertAt(row, 0);
                row = dtbl.NewRow();
                row["node_name"] = "Wszystkie";
                dtbl.Rows.InsertAt(row, 1);
                comboBox2.DataSource = dtbl;
                comboBox2.DisplayMember = "node_name";
                comboBox2.ValueMember = "node_number";
                comboBox2.SelectedItem = "Wybierz";
            }
        }
        public void Message()
        {
            string duplicateName = "";
            string copynamegroupName = "";
            string copyvaluewynikName = "Brak obrabiarek w bazie danych o podanych kryteriach";
            string niedable = "";
            copynamegroup = copynamegroup.Distinct().ToList();
            copyvaluewynik = copyvaluewynik.Distinct().ToList();
            foreach (var i in listWithDoubleDistinct)
            {
                duplicateName += i + " , ";
            }
            if (duplicateName.Length > 0)
                duplicateName = duplicateName.Remove(duplicateName.Length - 2);
            foreach (var i in copynamegroup)
            {
                copynamegroupName += i + " ";
            }
            foreach (var i in copyvaluewynik)
            {
                if (i == null)
                {
                    copyvaluewynikName += "Brak obrabiarek w bazie danych o podanych kryteriach";
                }
                else
                {
                    copyvaluewynikName += i + " ,";
                }
            }
            for (int i = 0; i < copynamegroup.Count; i++)
            {
                if (copyvaluewynik[i] == null)
                {
                    niedable += copynamegroup.ElementAt(i) + "\r\n " + "Brak obrabiarek w bazie danych o podanych kryteriach" + "\r\n ";
                }
                else
                    niedable += copynamegroup.ElementAt(i) + "\r\n " + copyvaluewynik.ElementAt(i) + "\r\n ";
            }
            if (zdublowaneWynik == null)
            {
                zdublowaneWynik = "Brak obrabiarek w bazie danych o podanych kryteriach";
            }
            message = string.Format("Dobrane obrabiarki :\r\n {0} :\r\n {1} \r\n {2} ", duplicateName, zdublowaneWynik, niedable);
            sklejka.Add(zdublowaneWynik);
            sklejka.AddRange(copyvaluewynik);
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            Message();
            DialogResult result = MessageBox.Show(message, "Czy przypisać do procesu?", MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        Reservation();
                        this.Text = "[Przypisz obrabiarki do procesu]";
                        installCombobox3();
                        panel1.Hide();
                        panel2.Show();                       
                        label7.Hide();
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        label7.Show();
                        this.Text = "[Zdefiniuj ręcznie]";
                        installCombobox1();
                        panel2.Hide();
                        panel1.Show();
                        metroButton4.Hide();
                        break;
                    }
            }
        }
        public void Reservation()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = concatenateQueryUpdate();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        }
        public void ReservationDataGrid(string query)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string CmdString = query;
                    cmd = new SqlCommand(CmdString, sqlCon);
                    sqlDa = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    query = "";
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Coś poszło nie tak", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private string concatenateQueryUpdate()
        {
            copynameTable = copynameTable.Distinct().ToList();
            string query = "";
            for (int i = 0; i < nameTable.Count; i++)
            {
                query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ", nameTable.ElementAt(i), zdublowaneWynik);
            }
            for (int j = 0; j < copyvaluewynik.Count; j++)
            {
                if (copyvaluewynik.ElementAt(j) != null)
                {
                    for (int i = 0; i < copynameTable.Count; i++)
                    {
                        query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ", copynameTable.ElementAt(i), copyvaluewynik.ElementAt(j));
                    }
                }
            }
            return query;
        }
        public void installCombobox1()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select DISTINCT rodzaj_obrabiarki from ZdefiniowaneObrabiarki ";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DataRow row = dtbl.NewRow();
                row["rodzaj_obrabiarki"] = "Wybierz";
                dtbl.Rows.InsertAt(row, 0);
                row = dtbl.NewRow();
                row["rodzaj_obrabiarki"] = "Wszystkie";
                dtbl.Rows.InsertAt(row, 1);
                for (int i = dtbl.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtbl.Rows[i];
                    if (dr["rodzaj_obrabiarki"] == "Frezarki")
                        dr.Delete();
                    if (dr["rodzaj_obrabiarki"] == "Tokarki")
                        dr.Delete();
                    if (dr["rodzaj_obrabiarki"] == "Wiertarki")
                        dr.Delete();
                }
                comboBox1.DataSource = dtbl;
                comboBox1.DisplayMember = "rodzaj_obrabiarki";
                comboBox1.SelectedItem = "Wybierz";
            }
        }
        private void metroButton7_Click(object sender, EventArgs e)
        {
            string selected = comboBox3.Text;
            string ID = comboBox3.SelectedValue.ToString();
            unqueryUpdateOne(selected);
            MessageBox.Show("Zwolniono", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void installCombobox3()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = "select DISTINCT rodzaj_obrabiarki from ZdefiniowaneObrabiarki ";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DataRow row = dtbl.NewRow();
                row["rodzaj_obrabiarki"] = "Wybierz";
                dtbl.Rows.InsertAt(row, 0);
                row = dtbl.NewRow();
                row["rodzaj_obrabiarki"] = "Wszystkie";
                dtbl.Rows.InsertAt(row, 1);
                for (int i = dtbl.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtbl.Rows[i];
                    if (dr["rodzaj_obrabiarki"] == "Frezarki")
                        dr.Delete();
                    if (dr["rodzaj_obrabiarki"] == "Tokarki")
                        dr.Delete();
                    if (dr["rodzaj_obrabiarki"] == "Wiertarki")
                        dr.Delete();
                }
                comboBox3.DataSource = dtbl;
                comboBox3.DisplayMember = "rodzaj_obrabiarki";
                comboBox3.SelectedItem = "Wybierz";
            }
        }
        private void metroButton9_Click(object sender, EventArgs e)
        {
            string selected = comboBox3.Text;
            string ID = comboBox3.SelectedValue.ToString();
            queryUpdateTwo(selected);
            MessageBox.Show("Przypisano", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string ID = comboBox1.SelectedValue.ToString();
            if (selected == "Wszystkie")
            {
                installDataGridMachine();
            }
            if (selected != "Wybierz" && selected != "Wszystkie")
            {
                installDataGridMachineByType(selected);
            }
        }
        private void metroButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zwolniono", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox3.Text;
            string ID = comboBox3.SelectedValue.ToString();
            if (selected == "Wszystkie")
            {
                installDataGridMachine3();
            }
            if (selected != "Wybierz" && selected != "Wszystkie")
            {
                installDataGridMachineByType3(selected);
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
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
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
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
            string query = "";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
            foreach (var i in weightMachine)
            {
                if (i != null)
                {
                    query += string.Format("SELECT [{0}].[Nazwa], [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa] like '%{1}%'  UNION ", selected, i.ToString());
                }
            }
            foreach (var i in sklejka)
            {
                if (i != null)
                {
                    query += string.Format("SELECT [{0}].[Nazwa], [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa] like '%{1}%'  UNION ", selected, i.ToString());
                }
            }
            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa]," +
                     " [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", selected, i.Item5, i.Item6, i.Item7);
            }

            query = query.Remove(query.Length - 6);
            return query;
        }
        public string concatenateQueryMachine3()
        {
            getAllKindOfMachineFromDataBase();
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");

            string query = "";

            //    fullListRodzajow = fullListRodzajow.Distinct().ToList();     
            foreach (var i in weightMachine)
            {
                if (i != null)
                {
                    foreach (var j in machineFromDatabase)
                    {
                        query += string.Format("SELECT [{0}].[Nazwa], [{0}].[X], [{0}].[Z] , [{0}].[Y], [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa] like '%{1}%'  UNION ", j.ToString(), i.ToString());
                    }
                }
            }
            foreach (var i in sklejka)
            {
                if (i != null)
                {
                    foreach (var j in machineFromDatabase)
                    {
                        query += string.Format("SELECT [{0}].[Nazwa], [{0}].[X], [{0}].[Z] , [{0}].[Y], [{0}].[Rezerwuj] From [{0}]  WHERE [{0}].[Nazwa] like '%{1}%'  UNION ", j.ToString(), i.ToString());
                    }
                }
            }
            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa]," +
                     " [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void installDataGridMachineByType(string selected)
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
                    string CmdString = concatenateQueryMachine(selected);
                    cmd = new SqlCommand(CmdString, sqlCon);
                    sqlDa = new SqlDataAdapter(cmd);
                    dtbl = new DataTable("Nazwa", "Rezerwuj");

                    sqlDa.Fill(dtbl);

                    dataGridView1.DataSource = dtbl;
                    int i = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Kontynuuj", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void installDataGridMachine()
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

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string CmdString = concatenateQueryMachine();
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable("Nazwa", "Rezerwuj");

                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;
                int i = 0;
            }
        }
        public string concatenateQueryMachine(string selected)
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");
            string query = "";
            foreach (var i in FULLTUPLEtoDB)
            {

                query += string.Format("select [{0}].[Nazwa]," +
                     " [{0}].[X], [{0}].[Z], [{0}].[Y] , [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", selected, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        public string concatenateQueryMachine()
        {
            var tttt = FULLTUPLEtoDB.GroupBy(x => x.Item3).Select(g => g.First()).ToList();
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Frezarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Wiertarki");
            FULLTUPLEtoDB.RemoveAll(item => item.Item3 == "Tokarki");

            string query = "";

            //    fullListRodzajow = fullListRodzajow.Distinct().ToList();

            foreach (var i in FULLTUPLEtoDB)
            {
                query += string.Format("select [{0}].[Nazwa]," +
                     " [{0}].[X], [{0}].[Z] ,[{0}].[Y], [{0}].[Rezerwuj] From [{0}] " +
                     "Where X<={1} AND Y<={2} AND Z<={3} AND Rezerwuj='false' UNION ", i.Item3, i.Item5, i.Item6, i.Item7);
            }
            query = query.Remove(query.Length - 6);
            return query;
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string ID = comboBox1.SelectedValue.ToString();
            queryUpdateOne(selected);
            MessageBox.Show("Przypisano", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void unqueryUpdateOne(string selected)
        {
            reservedMachine.Clear();
            getAllKindOfMachineFromDataBase();
            string query = "";
            DataTable changes = ((DataTable)dataGridView2.DataSource).GetChanges();
            foreach (DataRow row in changes.Rows)
            {
                reservedMachine.Add(row[0].ToString());
            }
            if (selected == "Wszystkie")
            {
                for (int k = 0; k < reservedMachine.Count; k++)
                {
                    for (int i = 0; i < machineFromDatabase.Count; i++)
                    {
                        query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='false' Where  [{0}].[Nazwa] like '%{1}%' ",
                            machineFromDatabase.ElementAt(i), reservedMachine.ElementAt(k));
                    }
                }
                ReservationDataGrid(query);
            }
            else
            {
                for (int i = 0; i < reservedMachine.Count; i++)
                {
                    query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='false' Where  [{0}].[Nazwa] like '%{1}%' ", selected, reservedMachine.ElementAt(i));
                }
                ReservationDataGrid(query);
            }
            query = "";
        }
        public void queryUpdateOne(string selected)
        {
            reservedMachine.Clear();
            getAllKindOfMachineFromDataBase();
            string query = "";
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();
            foreach (DataRow row in changes.Rows)
            {
                reservedMachine.Add(row[0].ToString());
            }
            if (selected == "Wszystkie")
            {
                for (int k = 0; k < reservedMachine.Count; k++)
                {
                    for (int i = 0; i < machineFromDatabase.Count; i++)
                    {
                        query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ",
                            machineFromDatabase.ElementAt(i), reservedMachine.ElementAt(k));
                    }
                }
                ReservationDataGrid(query);
            }
            else
            {
                for (int i = 0; i < reservedMachine.Count; i++)
                {
                    query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ", selected, reservedMachine.ElementAt(i));
                }
                ReservationDataGrid(query);
            }
            query = "";
        }
        public void queryUpdateTwo(string selected)
        {
            reservedMachine.Clear();

            getAllKindOfMachineFromDataBase();
            string query = "";
            DataTable changes = ((DataTable)dataGridView2.DataSource).GetChanges();
            foreach (DataRow row in changes.Rows)
            {
                reservedMachine.Add(row[0].ToString());
            }
            if (selected == "Wszystkie")
            {
                for (int k = 0; k < reservedMachine.Count; k++)
                {
                    for (int i = 0; i < machineFromDatabase.Count; i++)
                    {
                        query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ",
                            machineFromDatabase.ElementAt(i), reservedMachine.ElementAt(k));
                    }
                }
                ReservationDataGrid(query);
            }
            else
            {
                for (int i = 0; i < reservedMachine.Count; i++)
                {
                    query += string.Format("Update [{0}] SET  [{0}].[Rezerwuj]='true' Where  [{0}].[Nazwa] like '%{1}%' ", selected, reservedMachine.ElementAt(i));
                }
                ReservationDataGrid(query);
            }
            query = "";
        }
        public void getAllKindOfMachineFromDataBase()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "";
                sqlCon.Open();
                string CmdString = "Select rodzaj_obrabiarki from RodzajeObrabiarek";
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
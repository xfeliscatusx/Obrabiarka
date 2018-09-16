using Obrabiarka.ExtensionMethod;
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

    public partial class Zdefiniuj_obrabiarki : MetroFramework.Forms.MetroForm
    {
        private Proces_technologiczny _parent;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt, dt2, dt3;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        TreeNode GroupOfMachine, TypeOfMachine;
        List<string> operation = new List<string>();
        string CmdString, GroupOfMachineId, TypeOfMachineId, NameOfMachineGroup, NameOfMachineType;
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        List<string> tickList = new List<string>();
        List<string> compareName = new List<string>() { "Tokarki", "Frezarki", "Wiertarki" };
        List<string> generatedList = new List<string>();
        List<string> wagi = new List<string>();
        string TempNodeText = "";
        Waga frm = new Waga();
        string x, y, z;
        Kryteria kryteriaXYZ = new Kryteria();
        Kryteria2 kryteriaXC = new Kryteria2();

        // Dictionary<string, string> pairWeightAndNodeName = new Dictionary<string, string>();
        Tuple<string, string> tuple = Tuple.Create("1","Brak");
        List<string> listOftools=new List<string>();
        List<Tuple<string, string>> pairWeightAndNodeName = new List<Tuple<string, string>>();
        Tuple<int, string, string, int> finishTuple = Tuple.Create(1, "Brak", "brak",1);
        List<Tuple<int, string, string,int>> finishTupleList = new List<Tuple<int, string,string,int>>();
        Tuple<string, int, int, int> finishTupleKryteria = Tuple.Create("",0,0,0);
        List<Tuple<string, int, int, int>> finishTupleListKryteria = new List<Tuple<string, int, int, int>>();
        string selectedOneNode;
        List<TreeNode> operationNodesToAllProcess =new List<TreeNode>();
        string respone;
        List<String> listOfChecked = new List<string>();
        Tuple<string,string, string,string> kryteria = Tuple.Create("", "","","");
        List<Tuple<string,string, string,string>> kryteriaParametryXYZ = new List<Tuple<string,string, string,string>>();
        Tuple<int, string, string, int, int, int, int> FULLTUPLE = Tuple.Create(0, "", "", 0, 0, 0, 0);
        List<Tuple<int, string, string, int, int, int, int>> FULLTUPLEtoDB = new List<Tuple<int, string, string, int, int, int, int>>();
        public Zdefiniuj_obrabiarki(Proces_technologiczny parent)
        {
            _parent = parent; // assign the ref of the parent
            InitializeComponent();
            getMachineNames(_parent);
            Obrabiarki_Load();

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }

        }
        void f2_machine()
        {
            TreeNode node = treeView1.SelectedNode;
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            List<TreeNode> Nodes = new List<TreeNode>();
            Nodes.Clear();
            operationNodesToAllProcess.Clear();
            AddChildren(Nodes, node);
            getAllTuples();
            string value = operationNodesToAllProcess[0].Text.ToString();

            TempNodeText = frm.returnValue();

            if (listOftools.Contains(selectedOneNode))
            {
                int element = listOftools.IndexOf(selectedOneNode);
                tuple = new Tuple<string, string>(TempNodeText, selectedOneNode);
                pairWeightAndNodeName.RemoveAt(element);
                pairWeightAndNodeName.Insert(element, tuple);
            }
            if (selectedOneNode == (value))
            {
                Nodes.AddRange(operationNodesToAllProcess);
                foreach (var j in Nodes)
                {
                    int element2 = listOftools.IndexOf(j.Text.ToString());
                    tuple = new Tuple<string, string>(TempNodeText, j.Text.ToString());
                    pairWeightAndNodeName.RemoveAt(element2);
                    pairWeightAndNodeName.Insert(element2, tuple);
                }
            }
            {

                var aaa = pairWeightAndNodeName;
            }
        }
        void kryteriaXYZf()
        {
            x = kryteriaXYZ.returnValueX();
            y = kryteriaXYZ.returnValueY();
            z = kryteriaXYZ.returnValueZ();
            createListOfParameters();
        }
        void createListOfParameters()
        {

            //kryteriaParametryXYZ.Add(kryteria);

            TreeNode node = treeView1.SelectedNode;
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            List<TreeNode> Nodes = new List<TreeNode>();
            Nodes.Clear();
            operationNodesToAllProcess.Clear();
            AddChildren(Nodes, node);
            getAllTuples();
            string value = operationNodesToAllProcess[0].Text.ToString();

            TempNodeText = frm.returnValue();

            if (listOftools.Contains(selectedOneNode))
            {
                int element = listOftools.IndexOf(selectedOneNode);
                kryteria = new Tuple<string, string, string, string>(selectedOneNode,x, y, z);
                kryteriaParametryXYZ.RemoveAt(element);
                kryteriaParametryXYZ.Insert(element, kryteria);
            }
            if (selectedOneNode == (value))
            {
                Nodes.AddRange(operationNodesToAllProcess);
                foreach (var j in Nodes)
                {
                    int element2 = listOftools.IndexOf(j.Text.ToString());
                    kryteria = new Tuple<string, string, string, string>(j.Text.ToString(), x, y, z);
                    kryteriaParametryXYZ.RemoveAt(element2);
                    kryteriaParametryXYZ.Insert(element2, kryteria);
                }
            }
            {

                var aaa = kryteriaParametryXYZ;
            }
        }
        void kryteriaXCf()
        {
            x = kryteriaXC.returnValueSR();
            y = kryteriaXC.returnValueDL();
            z = null;
            createListOfParameters();

        }
        public void AddChildren(List<TreeNode> Nodes, TreeNode Node)
        {
            foreach (TreeNode thisNode in Node.Nodes)
            {
                Nodes.Add(thisNode);
                AddChildren(Nodes, thisNode);
            }
        }
        public void getAllTuples()
        {
            TreeNode node = treeView1.SelectedNode;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            operationNodesToAllProcess.Add(node);
        }
        public string getOneCHild(object sender, TreeViewEventArgs e)
        {
            selectedOneNode = e.Node.Text;
            return selectedOneNode;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedOneNode = e.Node.Text;
            
        }

        private void podajWagęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.eventList += new WagaAdd(f2_machine);
            frm.ShowDialog();
            TempNodeText = frm.Text;
            frm.Hide();
        }

        private void kryteriaWyboruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getAllTuples();
            string value = operationNodesToAllProcess[0].Text.ToString();
            if (value == "Frezarki" || value == "Wiertarki")
            {
                kryteriaXYZ.eventList += new Kryteria1(kryteriaXYZf);
                kryteriaXYZ.ShowDialog();
              //  TempNodeText = kryteriaXYZ.Text;
                kryteriaXYZ.Hide();
            }
            else
            {
                kryteriaXC.eventList += new Kryteria22(kryteriaXCf);
                kryteriaXC.ShowDialog();
                //  TempNodeText = kryteriaXYZ.Text;
                kryteriaXC.Hide();
            }
            operationNodesToAllProcess.Clear();
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Zdefiniuj_obrabiarki_Load(object sender, EventArgs e)
        {
            foreach (TreeNode RootNode in treeView1.Nodes)
            {
                RootNode.ContextMenuStrip = contextMenuStrip1;
                foreach (TreeNode ChildNode in RootNode.Nodes)
                {
                    ChildNode.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }
        void treeView1MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);

                if (treeView1.SelectedNode != null)
                {
                    selectedOneNode = treeView1.SelectedNode.Text;
                }

               // respone= treeView1.SelectedNode.Tag.ToString();
            }
        }

        private void Obrabiarki_Load()
        {
            con = new SqlConnection(ConString);
            CmdString = treeviewquery();
            cmd = new SqlCommand(CmdString, con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GroupOfMachineId = dt.Rows[i]["id_obrabiarki"].ToString();
                NameOfMachineGroup = dt.Rows[i]["grupa_obrabiarek"].ToString();
                GroupOfMachine = new TreeNode(NameOfMachineGroup);
                CmdString = "SELECT id_rodzajeobrabiarek, rodzaj_obrabiarki FROM RodzajeObrabiarek WHERE id_obrabiarki=@id_obrabiarki";
                cmd = new SqlCommand(CmdString, con);
                cmd.Parameters.AddWithValue("@id_obrabiarki", GroupOfMachineId);
                sda = new SqlDataAdapter(cmd);
                dt2 = new DataTable();
                sda.Fill(dt2);
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    TypeOfMachineId = dt2.Rows[j]["id_rodzajeobrabiarek"].ToString();
                    NameOfMachineType = dt2.Rows[j]["rodzaj_obrabiarki"].ToString();
                    TypeOfMachine = new TreeNode(NameOfMachineType);
                    GroupOfMachine.Nodes.Add(TypeOfMachine);
                }
                treeView1.Nodes.Add(GroupOfMachine);
                treeView1.ExpandAll();
                this.treeView1.CheckBoxes = true;
            }
            listOftools = treeView1.Nodes.Descendants().Select(n => n.Text).ToList();
            foreach (var i in listOftools)
            {
                tuple = new Tuple<string, string>("1", i);
                pairWeightAndNodeName.Add(tuple);
                kryteria = new Tuple<string, string, string, string>(i, "0", "0", "0");
                kryteriaParametryXYZ.Add(kryteria);
            }

        }
        private string treeviewquery()
        {
            string query = "";
            string zapytanieDoDrzewa;
            for (int i = 0; i < generatedList.Count; i++)
            {
                query += string.Format("grupa_obrabiarek='{0}' OR ", generatedList[i]);
            }
            zapytanieDoDrzewa = "SELECT id_obrabiarki, grupa_obrabiarek FROM Obrabiarki Where " + query;
            zapytanieDoDrzewa = zapytanieDoDrzewa.Substring(0, zapytanieDoDrzewa.Length - 3);
            return zapytanieDoDrzewa;
        }
        public void getMachineNames(Proces_technologiczny _parent)
        {
            operation = _parent.returnListOperation();
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = String.Format("select [dbo].[Operacje].Tokarki, [dbo].[Operacje].Frezarki,[dbo].[Operacje].Wiertarki FROM [Operacje] where nazwa_operacji='{0}'", operation[0]);
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {
                    tickList.Add(row[0].ToString());
                    tickList.Add(row[1].ToString());
                    tickList.Add(row[2].ToString());

                }
            }
            compareNameMethod();
            treeviewquery();

        }
        private void compareNameMethod()
        {
            for (int i = 0; i < compareName.Count; i++)
            {
                if (tickList[i] == "True")
                    generatedList.Add(compareName[i]);
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            operation.Clear();
            tickList.Clear();
            generatedList.Clear();
            this.Close();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {

            int result;
            int.TryParse(operation[1], out result);


            listOfChecked = treeView1.Nodes.Descendants()
                  .Where(n => n.Checked)
                  .Select(n => n.Text)
                  .ToList();
            foreach (var item in pairWeightAndNodeName)
            {
                if (listOfChecked.Contains(item.Item2))
                {
                    int element2 = listOfChecked.IndexOf(item.Item2);
                    int resultWaga;
                    int.TryParse(item.Item1, out resultWaga);
                    finishTuple = new Tuple<int, string,string,int>(result, operation[0],item.Item2, resultWaga);
                    finishTupleList.Add(finishTuple);          
                }
            }
        
            foreach(var item in kryteriaParametryXYZ)
            {
                if (listOfChecked.Contains(item.Item1))
                {
                    int xx, yy,zz;
                    int.TryParse(item.Item2, out xx);
                    int.TryParse(item.Item3, out yy);
                    int.TryParse(item.Item4, out zz);
                    int element2 = listOfChecked.IndexOf(item.Item1);
                    finishTupleKryteria = new Tuple<string, int,int, int>(item.Item1, xx,yy,zz);
                    finishTupleListKryteria.Add(finishTupleKryteria);
                }
            }
            joinTuple();
            operation.Clear();
            tickList.Clear();
            generatedList.Clear();
            this.Dispose();
        }
        private void insertTupleToDatabase()
        {

        }
        private void joinTuple()
        {
            string query = "";
            for (int i = 0; i < finishTupleListKryteria.Count; i++)
            {
                int result = finishTupleList.ElementAt(i).Item1;
                string operationName = finishTupleList.ElementAt(i).Item2;
                string rodzaj_obrabiarki = finishTupleList.ElementAt(i).Item3;
                int wagi = finishTupleList.ElementAt(i).Item4;
                int x = finishTupleListKryteria.ElementAt(i).Item2;
                int y = finishTupleListKryteria.ElementAt(i).Item3;
                int z = finishTupleListKryteria.ElementAt(i).Item4;
                FULLTUPLE = new Tuple<int, string, string, int, int, int, int>(result,operationName,rodzaj_obrabiarki,wagi,x,y,z);
                FULLTUPLEtoDB.Add(FULLTUPLE);
                query+= string.Format("insert into [dbo].[ZdefiniowaneObrabiarki] (node_number, node_name, rodzaj_obrabiarki, waga, X, Y,Z)" +
                    " Values('{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}') ", result, operationName, rodzaj_obrabiarki, wagi, x, y, z);

            }
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = query;
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
            }
        }
        private void truncateTable()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = "TRUNCATE TABLE [dbo].[ZdefiniowaneObrabiarki];";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
            }
        }
    }
}
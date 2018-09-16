using Obrabiarka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obrabiarka.ExtensionMethod;
using MetroFramework.Forms;
using MetroFramework;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Obrabiarka
{
    public delegate void numberofChildNode3();

    public partial class Proces_technologiczny : MetroFramework.Forms.MetroForm
    {

        public event numberofChildNode3 numberNodeChild;

        Dodaj_zabieg fTadd = new Dodaj_zabieg();
        Dodaj_zamocowanie fZadd = new Dodaj_zamocowanie();
        Dodaj_operacje fOadd = new Dodaj_operacje();
        public List<string> lista_obrabiarek;
        public List<string> lista_narzedzi;
        SqlCommand cmd;
        SqlDataAdapter sqlDa;
        DataTable dtbl;
        private static string ConString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        List<string> toczenie = new List<string>() { "Tokarki karuzelowe", "Tokarki poziome", "Tokarki XZ", "Tokarki XZC z napedzanym narzedziem" };
        List<string> frezowanie = new List<string>() { "Frezarki 3 osiowe", "Frezarki 4 osiowe z napedzanym narzedziem", "Frezarki 5 osiowe" };
        List<string> wiercenie = new List<string>() { "Wiertarki reczne", "Wiertarki CNC" };
        List<string> szlifierki = new List<string>() { "Szlifierki bezklowe", "Szlifierki klowe" };
        List<string> frezy = new List<string>() { "Frezy palcowe", "Frezy tarczowe" };
        List<string> narzedziaTokarskie = new List<string>() { "Narzedzia tokarskie lewe", "Narzedzia tokarskie prawe" };
        List<string> wiertla = new List<string>() { "Wiertla pelnoweglikowe", "Wiertla skladane" };
        List<string> wytaczaki = new List<string>() { "Wytaczaki tokarskie hakowe", "Wytaczaki tokarskie proste", "Wytaczaki tokarskie spiczaste" };
        List<string> operationNodesToAllProcess = new List<string>();
        List<string> listOfMachineFromTreeView = new List<string>();
        List<string> listOfToolsFromTreeView = new List<string>();
        List<string> listOfMachineToSend = new List<string>();
        List<string> listOfToolsToSend = new List<string>();

        /// ///////////////////////////////////////////////////////
        List<string> listOneOperationToDefinition = new List<string>();
        List<string> listOneToolToDefinition = new List<string>();
        List<TreeNode> parents = new List<TreeNode>();
        int vrr;
        public int numberofChildTreeView;

        public Proces_technologiczny()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.treeView1.AllowDrop = true;
            this.listView1.AllowDrop = true;
            this.listView2.AllowDrop = true;
            this.listView3.AllowDrop = true;
            this.listView1.View = View.List;
            this.listView2.View = View.List;
            this.listView3.View = View.List;
            this.treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            this.treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
            this.listView1.ItemDrag += listView1_ItemDrag;
            this.listView2.ItemDrag += listView2_ItemDrag;
            this.listView3.ItemDrag += listView3_ItemDrag;
        }
        public int numberofChild()
        {
            TreeNode node = treeView1.SelectedNode;
            numberofChildTreeView = GetIndex2(node);
            return numberofChildTreeView;
        }
        public List<string> returnListMachine()
        {
            return listOfMachineToSend;
        }
        public List<string> returnListTools()
        {
            return listOfToolsToSend;
        }
        public List<string> returnListOperation()
        {
            return listOneOperationToDefinition;
        }
        public List<string> returnToolListOperation()
        {
            return listOneToolToDefinition;
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Copy);
        }
        private void listView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView2.DoDragDrop(e.Item, DragDropEffects.Copy);
        }
        private void listView3_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView3.DoDragDrop(e.Item, DragDropEffects.Copy);
        }
        public void PopulateListView()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = "select [dbo].[Operacje].nazwa_operacji FROM [Operacje] Where [dbo].[Operacje].glowna='true'";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                foreach (DataRow row in dtbl.Rows)
                {
                    listView1.Items.Add(row[0].ToString());
                }
            }

            var list2 = fZadd.addAnchorageToList();
            this.listView2.Items.Add("zamocowanie 1");
            foreach (var i in list2)
            {
                this.listView2.Items.Add(i);
            }

            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                string CmdString = "select [dbo].[Zabiegi].nazwa_zabiegu FROM [Zabiegi] Where [dbo].[Zabiegi].glowna='true'";
                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                foreach (DataRow row in dtbl.Rows)
                {
                    listView3.Items.Add(row[0].ToString());
                }
            }
        }
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode n;
            if (e.Data.GetDataPresent("System.Windows.Forms.ListViewItem", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode dn = ((TreeView)sender).GetNodeAt(pt);
                ListViewItem item = (ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem");
                string name = item.ListView.Name.ToString();
                n = new TreeNode(item.Text);
                n.Tag = item;
                if (dn == null && name == "listView1")
                {
                    treeView1.Nodes.Add((TreeNode)n.Clone());
                }
                else if (dn == null && (name == "listView2" || name == "listView3"))
                {
                    MessageBox.Show("Nie możesz przenieść elementu w to miejsce." + Environment.NewLine + "Pamiętaj poziom 1 tworzą operacje, poziom 2 tworzą zamocowania, poziom 3 tworzą zabiegi!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dn.Level == 0 && name == "listView2")
                {
                    dn.Nodes.Add((TreeNode)n.Clone());
                    dn.Expand();
                }
                else if (dn.Level == 1 && name == "listView3")
                {
                    dn.Nodes.Add((TreeNode)n.Clone());
                    dn.Expand();
                }
                else if (dn.Level > 1)
                {
                    MessageBox.Show("Możesz definiować maksymalnie 3 poziomy!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                n.Remove();
            }
        }
        public void Proces_technologiczny_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            TreeNode dn = treeView1.SelectedNode;
            treeView1.Focus();
            dn.MoveUp();
            treeView1.BeginUpdate();
            treeView1.EndUpdate();
            dn.TreeView.SelectedNode = dn;
        }
        private void metroTile6_Click(object sender, EventArgs e)
        {
            TreeNode dn = treeView1.SelectedNode;
            treeView1.Focus();
            dn.MoveDown();
            treeView1.BeginUpdate();
            treeView1.EndUpdate();
            dn.TreeView.SelectedNode = dn;
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            try
            {
                fOadd.eventList += new OperationAdd(fOadd_eventList);
                fOadd.Show();
            }
            catch (Exception ex)
            {
                Dodaj_operacje fOadd = new Dodaj_operacje();
                fOadd.eventList += new OperationAdd(fOadd_eventList);
                fOadd.Show();
            }
        }
        void fOadd_eventList()
        {
            var list = fOadd.addOperationToList();
            foreach (var i in list)
            {
                this.listView1.Items.Add(i);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            fZadd.eventList2 += new AnchorageAdd(fZadd_eventList2);
            fZadd.Show();
        }
        void fZadd_eventList2()
        {
            var list2 = fZadd.addAnchorageToList();
            foreach (var i in list2)
            {
                this.listView2.Items.Add(i);
            }
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            fTadd.eventList3 += new TreatmentAdd(fTadd_eventList3);
            fTadd.Show();
        }
        void fTadd_eventList3()
        {
            var list3 = fTadd.addTreatmentToList();
            foreach (var i in list3)
            {
                this.listView3.Items.Add(i);
            }
        }
        private void generateNameOfTabelFromTreeView()
        {
            if (operationNodesToAllProcess.Contains("frezowanie"))
            {
                foreach (var i in frezowanie)
                {
                    listOfMachineFromTreeView.Add(i);
                }
                foreach (var i in frezy)
                {
                    listOfToolsFromTreeView.Add(i);
                }
            }
            if (operationNodesToAllProcess.Contains("toczenie"))
            {
                foreach (var i in toczenie)
                {
                    listOfMachineFromTreeView.Add(i);
                }
                foreach (var i in narzedziaTokarskie)
                {
                    listOfToolsFromTreeView.Add(i);
                }
            }
            if (operationNodesToAllProcess.Contains("wiercenie"))
            {
                foreach (var i in wiercenie)
                {
                    listOfMachineFromTreeView.Add(i);
                }
                foreach (var i in wiertla)
                {
                    listOfToolsFromTreeView.Add(i);
                }
            }
            if (operationNodesToAllProcess.Contains("szlifowanie"))
            {
                foreach (var i in szlifierki)
                {
                    listOfMachineFromTreeView.Add(i);
                }
                foreach (var i in wytaczaki)
                {
                    listOfToolsFromTreeView.Add(i);
                }
            }
        }
        private void compareNameOfTables(List<string> toSend, List<string> getFromTreeView, List<string> getFromWyposazenie)
        {
            var test2NotInTest1 = getFromTreeView.Where(t2 => getFromWyposazenie.Any(t1 => t2.Contains(t1)));

            foreach (var i in test2NotInTest1)
            {
                toSend.Add(i);
            }
        }
        private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }
        private void GetPathToRoot(TreeNode node, List<TreeNode> path)
        {
            if (node == null) return; // previous node was the root.
            else
            {
                path.Add(node);
                GetPathToRoot(node.Parent, path);
            }
        }
        private void metroTile12_Click(object sender, EventArgs e)
        {
            fOadd.eventList += new OperationAdd(fOadd_eventList);
            fOadd.Show();
        }
        private void metroTile11_Click(object sender, EventArgs e)
        {
            fZadd.eventList2 += new AnchorageAdd(fZadd_eventList2);
            fZadd.Show();
        }
        private void metroTile10_Click(object sender, EventArgs e)
        {
            fTadd.eventList3 += new TreatmentAdd(fTadd_eventList3);
            fTadd.Show();
        }
        private void metroTile9_Click(object sender, EventArgs e)
        {
            TreeNode dn = treeView1.SelectedNode;
            treeView1.Focus();
            dn.MoveUp();
            treeView1.BeginUpdate();
            treeView1.EndUpdate();
            dn.TreeView.SelectedNode = dn;
        }
        private void metroTile7_Click(object sender, EventArgs e)
        {
            TreeNode dn = treeView1.SelectedNode;
            treeView1.Focus();
            dn.MoveDown();
            treeView1.BeginUpdate();
            treeView1.EndUpdate();
            dn.TreeView.SelectedNode = dn;
        }
        private void metroTile8_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }
        private void metroTile7_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            Dodaj_obrabiarke f4 = new Dodaj_obrabiarke();
            f4.Show();
        }
        private void metroTile8_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            Zajete_obrabiarki fZO = new Zajete_obrabiarki();
            fZO.Show();
        }
        private void metroTile9_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            Dodaj_narzedzie f3 = new Dodaj_narzedzie();
            f3.Show();
        }
        private void metroTile10_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            Zajete_narzedzia fZN = new Zajete_narzedzia();
            fZN.Show();
        }
        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            Zdefiniuj_obrabiarki fZdO = new Zdefiniuj_obrabiarki(this);
            fZdO.Show();
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            Zdefiniuj_narzedzia fZdN = new Zdefiniuj_narzedzia(this);
            fZdN.Show();
        }
        private void metroTile16_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            Wyswietl_narzedzia fZdN = new Wyswietl_narzedzia(this);
            fZdN.Show();
        }
        private void metroTile19_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            Zajete_obrabiarki fZO = new Zajete_obrabiarki();
            fZO.Show();
        }
        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            Wyswietl_obrabiarki fWO = new Wyswietl_obrabiarki();
            fWO.Show();
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            Wyswietl_narzedzia fWN = new Wyswietl_narzedzia(this);
            fWN.Show();
        }
        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (numberNodeChild != null)
            {
                numberNodeChild();
            }
            listOneToolToDefinition.Clear();
            TreeNode node = treeView1.SelectedNode;
            listOneToolToDefinition.Add(node.Text);
            listOneToolToDefinition.Add(GetIndex2(node).ToString());

            numberofChildTreeView = GetIndex2(node);
            Zdefiniuj_narzedzia fZdN = new Zdefiniuj_narzedzia(this);
            this.SendToBack();
            fZdN.Show();
        }
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                listOneOperationToDefinition.Clear();
                TreeNode node = treeView1.SelectedNode;
                while (node.Parent != null)
                {
                    node = node.Parent;
                }
                vrr = GetIndex(node);
                listOneOperationToDefinition.Add(node.Text);
                listOneOperationToDefinition.Add(vrr.ToString());
                Zdefiniuj_obrabiarki fZdO = new Zdefiniuj_obrabiarki(this);
                this.SendToBack();
                fZdO.Show();
            }
            catch (Exception fe)
            {
                MessageBox.Show("Wybierz operacje!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(fe.Message);
            }
        }
        private void metroButton2_Click_2(object sender, EventArgs e)
        {
            this.SendToBack();
            Wyswietl_obrabiarki fWO = new Wyswietl_obrabiarki();
            fWO.Show();
        }
        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            TreeNode node = treeView1.SelectedNode;

            numberofChildTreeView = GetIndex2(node);

            Wyswietl_narzedzia fWN = new Wyswietl_narzedzia(this);
            fWN.Show();
        }
        private void metroTile8_Click_2(object sender, EventArgs e)
        {
            Zdefiniuj_operacje zdefiniujOperacje = new Zdefiniuj_operacje();

            this.SendToBack();
            zdefiniujOperacje.Show();
        }
        private void metroTile16_Click_1(object sender, EventArgs e)
        {
            Zdefiniuj_zabieg zdefiniujZabieg = new Zdefiniuj_zabieg();

            this.SendToBack();
            zdefiniujZabieg.Show();
        }
        private void metroTile17_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView2.Clear();
            listView3.Clear();
            PopulateListView();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private int GetIndex(TreeNode node)
        {
            // Always make a way to exit the recursion.
            if (node.Parent == null)
                return node.Index;

            return node.Index + GetIndex(node.Parent);
        }
        private void metroTile18_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy zbudować nowy proces?", "Uwaga!", MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        truncateTable();
                        treeView1.Nodes.Clear();
                        MessageBox.Show("Przejdz do definiownia nowego procesu!");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }
        private void truncateTable()
        {
            string CmdString = null;
            using (SqlConnection sqlCon = new SqlConnection(ConString))
            {
                sqlCon.Open();
                CmdString += "TRUNCATE TABLE [dbo].[ZdefiniowaneObrabiarki] ";
                CmdString += "TRUNCATE TABLE [dbo].[ZdefiniowaneNarzedzia]";

                cmd = new SqlCommand(CmdString, sqlCon);
                sqlDa = new SqlDataAdapter(cmd);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);
            }
        }
        private int GetIndex2(TreeNode node)
        {
            int returnValue = 0;

            // Always make a way to exit the recursion.
            if (node.Index == 0 && node.Parent == null)
                return returnValue;

            // Now, count every node.
            returnValue = 1;

            // If I have siblings higher in the index, then count them and their decendants.
            if (node.Index > 0)
            {
                TreeNode previousSibling = node.PrevNode;
                while (previousSibling != null)
                {
                    returnValue += GetDecendantCount(previousSibling);
                    previousSibling = previousSibling.PrevNode;
                }
            }

            if (node.Parent == null)
                return returnValue;
            else
                return returnValue + GetIndex2(node.Parent);
        }
        public int GetDecendantCount(TreeNode node)
        {
            int returnValue = 0;

            // If the node is not the root node, then we want to count it.
            if (node.Index != 0 || node.Parent != null)
                returnValue = 1;

            // Always make a way to exit a recursive function.
            if (node.Nodes.Count == 0)
                return returnValue;

            foreach (TreeNode childNode in node.Nodes)
            {
                returnValue += GetDecendantCount(childNode);
            }
            return returnValue;
        }
        private void metroTile14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy zapisać strukturę procesu?", "Uwaga!", MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        SaveTree(treeView1, @"C:\Users\Monika\Desktop\treeView.txt");
                        MessageBox.Show("Zapisano!");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }
        private void metroTile15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy wczytać strukturę procesu?", "Uwaga!", MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        LoadTree(treeView1, @"C:\Users\Monika\Desktop\treeView.txt");
                        MessageBox.Show("Wczytano!");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }
        public static void SaveTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
            }
        }
        public static void LoadTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object obj = bf.Deserialize(file);

                TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                tree.Nodes.AddRange(nodeList);
            }
        }
    }
}
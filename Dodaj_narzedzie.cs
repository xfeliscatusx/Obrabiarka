﻿using System;
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
    public partial class Dodaj_narzedzie : MetroFramework.Forms.MetroForm
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
        int B = 120;
        int BB = 23;
        int C = 120;
        int TextBoxCount = 0;
        int i = 0;
        List<TextBox> listTxt = new List<TextBox>();
        List<string[]> myObjectList = new List<string[]>();
        List<Label> label = new List<Label>();
        public Dodaj_narzedzie()
        {
            InitializeComponent();
        }
        private void Dodaj_narzedzie_Load(object sender, EventArgs e)
        {
            this.rodzajeNarzedziTableAdapter.Fill(this.contactDBDataSet.RodzajeNarzedzi);
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MONIKA\\OBRABIARKA\\OBRABIARKA\\CONTACTDB.MDF;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand sc = new SqlCommand("select id_rodzajenarzedzi,rodzaj_narzedzia from RodzajeNarzedzi", conn);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id_rodzajenarzedzi", typeof(string));
            dt.Columns.Add("rodzaj_narzedzia", typeof(string));
            dt.Load(reader);                        
            comboBox1.ValueMember = "id_rodzajenarzedzi";
            comboBox1.DisplayMember = "rodzaj_narzedzia";
            comboBox1.DataSource = dt;

            conn.Close();
        }
        private string load_Column_Names()
        {
            string klucz = comboBox1.Text;
            string format = string.Format("select Column_name from Information_schema.columns where Table_name like '{0}'", klucz);
            return format;
        }
        private string Insert_Values()
        {
            var value = "null";
            string klucz = string.Format("[{0}]", comboBox1.Text);
            List<string> value_test = new List<string>();
            List<string> txt_test = new List<string>();
            foreach (var ii in myObjectList)
            {
                int j = 0;
                value_test.Add(ii[j].ToString());
                j++;
            }
            foreach (var ii in listTxt)
            {
                txt_test.Add(ii.Text);
            }
            value = String.Join("],[", value_test.ToList());
            string value_txt = String.Join("','", txt_test);
            string format = string.Format("INSERT INTO {0} ([{1}], [Rezerwuj]) VALUES ('{2}','false');", klucz, value, value_txt);
            return format;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = Insert_Values();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
           MessageBox.Show("Narzędzie zostało dodane do bazy danych");
            //MetroMessageBox.Show(this, "Narzędzie zostało dodane do bazy danych", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            RemoveControls();
        }
        public TextBox AddNewTextBox()
        {
            TextBox txt = new TextBox();
            this.Controls.Add(txt);
            txt.Top = C;
            txt.Left = 190;
            txt.Size = new System.Drawing.Size(215, 86);
            txt.Name = "TextBox" + i;
            C = C + 35;
            i++;
            return txt;
        }
        public List<Label> AddNewLabel(List<string[]> listaobiektow)
        {
            foreach (var ele in listaobiektow)
            {
                Label abc = new Label();
                abc.AutoSize = true;
                abc.Font = new Font("Open Sans", 10);
                int i = 0;
                this.Controls.Add(abc);
                abc.Top = B;
                abc.Left = BB;
                abc.Text = ele[i].ToString();
                B = B + 35;
                label.Add(abc);
                i++;
            }
            return label;
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = load_Column_Names();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = conn;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] myObject = NewMethod(reader);
                    int instances = reader.GetValues(myObject);
                    myObjectList.Add(myObject);
                    //AddNewLabel(myObject);
                }
                myObjectList.RemoveAt(0);
                if (myObjectList.Any()) //prevent IndexOutOfRangeException for empty list
                {
                    myObjectList.RemoveAt(myObjectList.Count - 1);
                }
                AddNewLabel(myObjectList);
                TextBoxCount = myObjectList.Count;
                for (int i = 0; i < TextBoxCount; i++)
                {
                    listTxt.Add(AddNewTextBox());
                }
            }
            B = 120;
            C = 120;
        }
        private static string[] NewMethod(SqlDataReader reader)
        {
            return new string[reader.FieldCount];
        }               
        private void RemoveControls()
        {
            //this.Controls.Clear(); //to remove all controls
            foreach (TextBox tb in listTxt)
            {
                tb.Dispose();
            }
            foreach (Label lb in label)
            {
                lb.Dispose();
            }
            myObjectList.Clear();
            listTxt.Clear();
            label.Clear();
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (TextBox tb in listTxt)
            {
                tb.Dispose();
            }
            foreach (Label lb in label)
            {
                lb.Dispose();
            }
            myObjectList.Clear();
            listTxt.Clear();
            label.Clear();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string query = Insert_Values();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Narzędzie zostało dodane do bazy danych");
            //MetroMessageBox.Show(this, "Narzędzie zostało dodane do bazy danych", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            RemoveControls();
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = load_Column_Names();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = conn;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] myObject = NewMethod(reader);
                    int instances = reader.GetValues(myObject);
                    myObjectList.Add(myObject);
                    //AddNewLabel(myObject);
                }
                myObjectList.RemoveAt(0);
                if (myObjectList.Any()) //prevent IndexOutOfRangeException for empty list
                {
                    myObjectList.RemoveAt(myObjectList.Count - 1);
                }
                AddNewLabel(myObjectList);
                TextBoxCount = myObjectList.Count;
                for (int i = 0; i < TextBoxCount; i++)
                {
                    listTxt.Add(AddNewTextBox());
                }
            }
            B = 120;
            C = 120;
        }
    }
}
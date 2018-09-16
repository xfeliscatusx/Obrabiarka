namespace Obrabiarka
{
    partial class Dodaj_narzedzie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label rodzaj_obrabiarkiLabel;
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rodzajeNarzedziBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactDBDataSet = new Obrabiarka.ContactDBDataSet();
            this.rodzajeNarzedziTableAdapter = new Obrabiarka.ContactDBDataSetTableAdapters.RodzajeNarzedziTableAdapter();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            rodzaj_obrabiarkiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rodzajeNarzedziBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // rodzaj_obrabiarkiLabel
            // 
            rodzaj_obrabiarkiLabel.AutoSize = true;
            rodzaj_obrabiarkiLabel.Font = new System.Drawing.Font("Open Sans", 10.25F);
            rodzaj_obrabiarkiLabel.Location = new System.Drawing.Point(23, 79);
            rodzaj_obrabiarkiLabel.Name = "rodzaj_obrabiarkiLabel";
            rodzaj_obrabiarkiLabel.Size = new System.Drawing.Size(124, 19);
            rodzaj_obrabiarkiLabel.TabIndex = 12;
            rodzaj_obrabiarkiLabel.Text = "Rodzaj narzędzia";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(190, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // rodzajeNarzedziBindingSource
            // 
            this.rodzajeNarzedziBindingSource.DataMember = "RodzajeNarzedzi";
            this.rodzajeNarzedziBindingSource.DataSource = this.contactDBDataSetBindingSource;
            // 
            // contactDBDataSetBindingSource
            // 
            this.contactDBDataSetBindingSource.DataSource = this.contactDBDataSet;
            this.contactDBDataSetBindingSource.Position = 0;
            // 
            // contactDBDataSet
            // 
            this.contactDBDataSet.DataSetName = "ContactDBDataSet";
            this.contactDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rodzajeNarzedziTableAdapter
            // 
            this.rodzajeNarzedziTableAdapter.ClearBeforeFill = true;
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(348, 327);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 23);
            this.metroButton2.TabIndex = 36;
            this.metroButton2.Text = "Zamknij";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(239, 327);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 23);
            this.metroButton1.TabIndex = 35;
            this.metroButton1.Text = "Dodaj";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Dodaj_narzedzie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 373);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(rodzaj_obrabiarkiLabel);
            this.Name = "Dodaj_narzedzie";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = " Dodaj narzędzie";
            this.Load += new System.EventHandler(this.Dodaj_narzedzie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rodzajeNarzedziBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource contactDBDataSetBindingSource;
        private ContactDBDataSet contactDBDataSet;
        private System.Windows.Forms.BindingSource rodzajeNarzedziBindingSource;
        private ContactDBDataSetTableAdapters.RodzajeNarzedziTableAdapter rodzajeNarzedziTableAdapter;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}
namespace Obrabiarka
{
    partial class Dodaj_obrabiarke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dodaj_obrabiarke));
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contactDBDataSet = new Obrabiarka.ContactDBDataSet();
            this.tableAdapterManager = new Obrabiarka.ContactDBDataSetTableAdapters.TableAdapterManager();
            this.dodajObrabiarkeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dodajObrabiarkeTableAdapter = new Obrabiarka.ContactDBDataSetTableAdapters.DodajObrabiarkeTableAdapter();
            this.contactDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dodajObrabiarkeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.obrabiarkiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obrabiarkiTableAdapter = new Obrabiarka.ContactDBDataSetTableAdapters.ObrabiarkiTableAdapter();
            this.rodzajeObrabiarekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rodzajeObrabiarekTableAdapter = new Obrabiarka.ContactDBDataSetTableAdapters.RodzajeObrabiarekTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            rodzaj_obrabiarkiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodajObrabiarkeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodajObrabiarkeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obrabiarkiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodzajeObrabiarekBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rodzaj_obrabiarkiLabel
            // 
            rodzaj_obrabiarkiLabel.AutoSize = true;
            rodzaj_obrabiarkiLabel.Font = new System.Drawing.Font("Open Sans", 10.75F);
            rodzaj_obrabiarkiLabel.Location = new System.Drawing.Point(23, 87);
            rodzaj_obrabiarkiLabel.Name = "rodzaj_obrabiarkiLabel";
            rodzaj_obrabiarkiLabel.Size = new System.Drawing.Size(130, 20);
            rodzaj_obrabiarkiLabel.TabIndex = 11;
            rodzaj_obrabiarkiLabel.Text = "Rodzaj obrabiarki";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // contactDBDataSet
            // 
            this.contactDBDataSet.DataSetName = "ContactDBDataSet";
            this.contactDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DodajObrabiarkeTableAdapter = null;
            this.tableAdapterManager.NarzedziaTableAdapter = null;
            this.tableAdapterManager.ObrabiarkiTableAdapter = null;
            this.tableAdapterManager.RodzajeNarzedziTableAdapter = null;
            this.tableAdapterManager.RodzajeObrabiarekTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Obrabiarka.ContactDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dodajObrabiarkeBindingSource
            // 
            this.dodajObrabiarkeBindingSource.DataMember = "DodajObrabiarke";
            this.dodajObrabiarkeBindingSource.DataSource = this.contactDBDataSet;
            // 
            // dodajObrabiarkeTableAdapter
            // 
            this.dodajObrabiarkeTableAdapter.ClearBeforeFill = true;
            // 
            // contactDBDataSetBindingSource
            // 
            this.contactDBDataSetBindingSource.DataSource = this.contactDBDataSet;
            this.contactDBDataSetBindingSource.Position = 0;
            // 
            // dodajObrabiarkeBindingSource1
            // 
            this.dodajObrabiarkeBindingSource1.DataMember = "DodajObrabiarke";
            this.dodajObrabiarkeBindingSource1.DataSource = this.contactDBDataSetBindingSource;
            // 
            // obrabiarkiBindingSource
            // 
            this.obrabiarkiBindingSource.DataMember = "Obrabiarki";
            this.obrabiarkiBindingSource.DataSource = this.contactDBDataSetBindingSource;
            // 
            // obrabiarkiTableAdapter
            // 
            this.obrabiarkiTableAdapter.ClearBeforeFill = true;
            // 
            // rodzajeObrabiarekBindingSource
            // 
            this.rodzajeObrabiarekBindingSource.DataMember = "RodzajeObrabiarek";
            this.rodzajeObrabiarekBindingSource.DataSource = this.contactDBDataSetBindingSource;
            // 
            // rodzajeObrabiarekTableAdapter
            // 
            this.rodzajeObrabiarekTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(365, 308);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 23);
            this.metroButton2.TabIndex = 38;
            this.metroButton2.Text = "Zamknij";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(256, 308);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 23);
            this.metroButton1.TabIndex = 37;
            this.metroButton1.Text = "Dodaj";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Dodaj_obrabiarke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(478, 354);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(rodzaj_obrabiarkiLabel);
            this.Name = "Dodaj_obrabiarke";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Dodaj obrabiarkę";
            this.Load += new System.EventHandler(this.Dodaj_obrabiarke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodajObrabiarkeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodajObrabiarkeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obrabiarkiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodzajeObrabiarekBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContactDBDataSet contactDBDataSet;
        private ContactDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource dodajObrabiarkeBindingSource;
        private ContactDBDataSetTableAdapters.DodajObrabiarkeTableAdapter dodajObrabiarkeTableAdapter;
        private System.Windows.Forms.BindingSource contactDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource dodajObrabiarkeBindingSource1;
        private System.Windows.Forms.BindingSource obrabiarkiBindingSource;
        private ContactDBDataSetTableAdapters.ObrabiarkiTableAdapter obrabiarkiTableAdapter;
        private System.Windows.Forms.BindingSource rodzajeObrabiarekBindingSource;
        private ContactDBDataSetTableAdapters.RodzajeObrabiarekTableAdapter rodzajeObrabiarekTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}
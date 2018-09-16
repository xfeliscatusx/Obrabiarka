namespace Obrabiarka
{
    partial class Zdefiniuj_obrabiarki
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.podajWagęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryteriaWyboruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(22, 67);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(356, 253);
            this.treeView1.TabIndex = 34;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1MouseUp);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(287, 340);
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
            this.metroButton1.Location = new System.Drawing.Point(178, 340);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 23);
            this.metroButton1.TabIndex = 35;
            this.metroButton1.Text = "Dodaj";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podajWagęToolStripMenuItem,
            this.kryteriaWyboruToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 70);
            // 
            // podajWagęToolStripMenuItem
            // 
            this.podajWagęToolStripMenuItem.Name = "podajWagęToolStripMenuItem";
            this.podajWagęToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.podajWagęToolStripMenuItem.Text = "Podaj wagę";
            this.podajWagęToolStripMenuItem.Click += new System.EventHandler(this.podajWagęToolStripMenuItem_Click);
            // 
            // kryteriaWyboruToolStripMenuItem
            // 
            this.kryteriaWyboruToolStripMenuItem.Name = "kryteriaWyboruToolStripMenuItem";
            this.kryteriaWyboruToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.kryteriaWyboruToolStripMenuItem.Text = "Kryteria wyboru";
            this.kryteriaWyboruToolStripMenuItem.Click += new System.EventHandler(this.kryteriaWyboruToolStripMenuItem_Click);
            // 
            // Zdefiniuj_obrabiarki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 386);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.treeView1);
            this.Name = "Zdefiniuj_obrabiarki";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Zdefiniuj obrabiarki";
            this.Load += new System.EventHandler(this.Zdefiniuj_obrabiarki_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem podajWagęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kryteriaWyboruToolStripMenuItem;
    }
}
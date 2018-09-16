namespace Obrabiarka
{
    partial class Zdefiniuj_narzedzia
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.podajWagęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryteriaDoboruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(181, 342);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 23);
            this.metroButton1.TabIndex = 31;
            this.metroButton1.Text = "Dodaj";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(290, 342);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 23);
            this.metroButton2.TabIndex = 32;
            this.metroButton2.Text = "Zamknij";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(24, 73);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(356, 253);
            this.treeView1.TabIndex = 33;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podajWagęToolStripMenuItem,
            this.kryteriaDoboruToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            // 
            // podajWagęToolStripMenuItem
            // 
            this.podajWagęToolStripMenuItem.Name = "podajWagęToolStripMenuItem";
            this.podajWagęToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.podajWagęToolStripMenuItem.Text = "Podaj wagę";
            this.podajWagęToolStripMenuItem.Click += new System.EventHandler(this.podajWagęToolStripMenuItem_Click);
            // 
            // kryteriaDoboruToolStripMenuItem
            // 
            this.kryteriaDoboruToolStripMenuItem.Name = "kryteriaDoboruToolStripMenuItem";
            this.kryteriaDoboruToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.kryteriaDoboruToolStripMenuItem.Text = "Kryteria doboru";
            this.kryteriaDoboruToolStripMenuItem.Click += new System.EventHandler(this.kryteriaWyboruToolStripMenuItem_Click);
            // 
            // Zdefiniuj_narzedzia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 388);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Name = "Zdefiniuj_narzedzia";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Zdefiniuj narzędzia";
            this.Load += new System.EventHandler(this.Zdefiniuj_obrabiarki_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem podajWagęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kryteriaDoboruToolStripMenuItem;
    }
}
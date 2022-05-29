using System;
using System.Linq;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Utils;

namespace ToDoApp.Views
{
    partial class StartpageView
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
            this.BtnOpenAddTask = new System.Windows.Forms.Button();
            this.GridViewToDos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblGridView = new System.Windows.Forms.Label();
            this.LblMainTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewToDos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOpenAddTask
            // 
            this.BtnOpenAddTask.Location = new System.Drawing.Point(12, 415);
            this.BtnOpenAddTask.Name = "BtnOpenAddTask";
            this.BtnOpenAddTask.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenAddTask.TabIndex = 0;
            this.BtnOpenAddTask.Text = "New Todo";
            this.BtnOpenAddTask.UseVisualStyleBackColor = true;
            this.BtnOpenAddTask.Click += new System.EventHandler(this.BtnOpenAddTask_Click);
            // 
            // GridViewToDos
            // 
            this.GridViewToDos.AllowUserToAddRows = false;
            this.GridViewToDos.AllowUserToDeleteRows = false;
            this.GridViewToDos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewToDos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewToDos.Location = new System.Drawing.Point(12, 97);
            this.GridViewToDos.Name = "GridViewToDos";
            this.GridViewToDos.ReadOnly = false;
            this.GridViewToDos.RowHeadersVisible = false;
            this.GridViewToDos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.GridViewToDos.ShowCellToolTips = false;
            this.GridViewToDos.ShowEditingIcon = false;
            this.GridViewToDos.Size = new System.Drawing.Size(776, 286);
            this.GridViewToDos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(742, 389);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 206);
            this.textBox1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.ladenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Agenda Overview";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(713, 27);
            this.BtnSearch.Name = "button3";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            // 
            // LblGridView
            // 
            this.LblGridView.AutoSize = true;
            this.LblGridView.Location = new System.Drawing.Point(12, 81);
            this.LblGridView.Name = "label1";
            this.LblGridView.Size = new System.Drawing.Size(84, 13);
            this.LblGridView.TabIndex = 7;
            this.LblGridView.Text = "Tasks for Today";
            // 
            // LblMainTitle
            // 
            this.LblMainTitle.AutoSize = true;
            this.LblMainTitle.Location = new System.Drawing.Point(329, 36);
            this.LblMainTitle.Name = "label2";
            this.LblMainTitle.Size = new System.Drawing.Size(141, 13);
            this.LblMainTitle.TabIndex = 8;
            this.LblMainTitle.Text = "DAILY LIST TO DO TODAY";
            // 
            // StartpageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblMainTitle);
            this.Controls.Add(this.LblGridView);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GridViewToDos);
            this.Controls.Add(this.BtnOpenAddTask);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartpageView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridViewToDos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenAddTask;
        private System.Windows.Forms.DataGridView GridViewToDos;
        private Button button1;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem speichernToolStripMenuItem;
        private ToolStripMenuItem ladenToolStripMenuItem;
        private Button button2;
        private Button BtnSearch;
        private Label LblGridView;
        private Label LblMainTitle;
    }

}


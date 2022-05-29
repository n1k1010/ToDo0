using System.Globalization;

namespace ToDoApp.Views
{
    partial class AddTaskView
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Titel = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(12, 344);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "Schließen";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // dtDueDate
            // 
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
             this.dtDueDate.Location = new System.Drawing.Point(12, 69);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(276, 20);
            this.dtDueDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fälligkeitsdatum";
            // 
            // Titel
            // 
            this.Titel.AutoSize = true;
            this.Titel.Location = new System.Drawing.Point(13, 13);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(27, 13);
            this.Titel.TabIndex = 3;
            this.Titel.Text = "Titel";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(13, 30);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(276, 20);
            this.tbTitle.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(214, 344);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 379);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.Titel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDueDate);
            this.Controls.Add(this.BtnClose);
            this.Name = "AddTaskView";
            this.Text = "Todo Hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DataGridView GridViewTodos;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Titel;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnAdd;
    }
}
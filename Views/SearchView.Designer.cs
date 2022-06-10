namespace ToDoApp.Views
{
    partial class SearchView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.close = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.DueDate = new System.Windows.Forms.Label();
            this.searchDTPicker = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchgdv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchgdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(257, 199);
            this.dataGridView1.TabIndex = 0;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(228, 250);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "schließen";
            this.close.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(46, 250);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "suchen";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(55, 45);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(37, 13);
            this.status.TabIndex = 3;
            this.status.Text = "Status";
            this.status.Click += new System.EventHandler(this.label1_Click);
            // 
            // DueDate
            // 
            this.DueDate.AutoSize = true;
            this.DueDate.Location = new System.Drawing.Point(55, 117);
            this.DueDate.Name = "DueDate";
            this.DueDate.Size = new System.Drawing.Size(82, 13);
            this.DueDate.TabIndex = 4;
            this.DueDate.Text = "Fälligkeitsdatum";
            // 
            // searchDTPicker
            // 
            this.searchDTPicker.Location = new System.Drawing.Point(58, 150);
            this.searchDTPicker.Name = "searchDTPicker";
            this.searchDTPicker.Size = new System.Drawing.Size(200, 20);
            this.searchDTPicker.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // searchgdv
            // 
            this.searchgdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchgdv.Location = new System.Drawing.Point(362, 25);
            this.searchgdv.Name = "searchgdv";
            this.searchgdv.Size = new System.Drawing.Size(361, 199);
            this.searchgdv.TabIndex = 9;
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchgdv);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.searchDTPicker);
            this.Controls.Add(this.DueDate);
            this.Controls.Add(this.status);
            this.Controls.Add(this.search);
            this.Controls.Add(this.close);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SearchView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchgdv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label DueDate;
        private System.Windows.Forms.DateTimePicker searchDTPicker;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView searchgdv;
    }
}
namespace ToDo
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
            ((System.ComponentModel.ISupportInitialize)(this.GridViewToDos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOpenAddTask
            // 
            this.BtnOpenAddTask.Location = new System.Drawing.Point(32, 45);
            this.BtnOpenAddTask.Name = "BtnOpenAddTask";
            this.BtnOpenAddTask.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenAddTask.TabIndex = 0;
            this.BtnOpenAddTask.Text = "add task";
            this.BtnOpenAddTask.UseVisualStyleBackColor = true;
            this.BtnOpenAddTask.Click += new System.EventHandler(this.BtnOpenAddTask_Click);
            // 
            // GridViewToDos
            // 
            this.GridViewToDos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewToDos.Location = new System.Drawing.Point(277, 23);
            this.GridViewToDos.Name = "GridViewToDos";
            this.GridViewToDos.Size = new System.Drawing.Size(240, 150);
            this.GridViewToDos.TabIndex = 1;
            
            // 
            // StartpageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridViewToDos);
            this.Controls.Add(this.BtnOpenAddTask);
            this.Name = "StartpageView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridViewToDos)).EndInit();
            this.ResumeLayout(false);

         


        }

        #endregion
        private void SetUpUI()
        {
           
            GridViewToDos.DataSource = ToDos;
            


        }
        private System.Windows.Forms.Button BtnOpenAddTask;
        private System.Windows.Forms.DataGridView GridViewToDos;
        
    }

}


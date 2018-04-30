namespace TaskManagerWindows
{
    partial class frmProjectList
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
            this.listProjects = new System.Windows.Forms.ListBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnViewTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listProjects
            // 
            this.listProjects.FormattingEnabled = true;
            this.listProjects.ItemHeight = 14;
            this.listProjects.Location = new System.Drawing.Point(12, 12);
            this.listProjects.Name = "listProjects";
            this.listProjects.Size = new System.Drawing.Size(564, 172);
            this.listProjects.TabIndex = 0;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(501, 190);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(75, 23);
            this.btnAddProject.TabIndex = 1;
            this.btnAddProject.Text = "Add New";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnViewTasks
            // 
            this.btnViewTasks.Location = new System.Drawing.Point(12, 190);
            this.btnViewTasks.Name = "btnViewTasks";
            this.btnViewTasks.Size = new System.Drawing.Size(75, 23);
            this.btnViewTasks.TabIndex = 2;
            this.btnViewTasks.Text = "View Tasks";
            this.btnViewTasks.UseVisualStyleBackColor = true;
            this.btnViewTasks.Click += new System.EventHandler(this.btnViewTasks_Click);
            // 
            // frmProjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 304);
            this.Controls.Add(this.btnViewTasks);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.listProjects);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "frmProjectList";
            this.Text = "Project List";
            this.Load += new System.EventHandler(this.frmProjectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listProjects;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnViewTasks;
    }
}
namespace TaskManagerWindows
{
    partial class frmTaskList
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
            this.listTasks = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupTaskDetails = new System.Windows.Forms.GroupBox();
            this.lblCompleteStatus = new System.Windows.Forms.Label();
            this.groupTaskDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTasks
            // 
            this.listTasks.FormattingEnabled = true;
            this.listTasks.ItemHeight = 22;
            this.listTasks.Location = new System.Drawing.Point(12, 12);
            this.listTasks.Name = "listTasks";
            this.listTasks.Size = new System.Drawing.Size(420, 114);
            this.listTasks.TabIndex = 0;
            this.listTasks.SelectedIndexChanged += new System.EventHandler(this.listTasks_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 148);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "New Task";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupTaskDetails
            // 
            this.groupTaskDetails.Controls.Add(this.lblCompleteStatus);
            this.groupTaskDetails.Location = new System.Drawing.Point(12, 177);
            this.groupTaskDetails.Name = "groupTaskDetails";
            this.groupTaskDetails.Size = new System.Drawing.Size(420, 222);
            this.groupTaskDetails.TabIndex = 2;
            this.groupTaskDetails.TabStop = false;
            this.groupTaskDetails.Text = "Task Details";
            // 
            // lblCompleteStatus
            // 
            this.lblCompleteStatus.AutoSize = true;
            this.lblCompleteStatus.Location = new System.Drawing.Point(6, 25);
            this.lblCompleteStatus.Name = "lblCompleteStatus";
            this.lblCompleteStatus.Size = new System.Drawing.Size(99, 22);
            this.lblCompleteStatus.TabIndex = 0;
            this.lblCompleteStatus.Text = "Completed: ";
            // 
            // frmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 411);
            this.Controls.Add(this.groupTaskDetails);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.listTasks);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "frmTaskList";
            this.Text = "frmTaskList";
            this.Load += new System.EventHandler(this.frmTaskList_Load);
            this.groupTaskDetails.ResumeLayout(false);
            this.groupTaskDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTasks;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupTaskDetails;
        private System.Windows.Forms.Label lblCompleteStatus;
    }
}
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
            this.SuspendLayout();
            // 
            // listTasks
            // 
            this.listTasks.FormattingEnabled = true;
            this.listTasks.ItemHeight = 14;
            this.listTasks.Location = new System.Drawing.Point(12, 12);
            this.listTasks.Name = "listTasks";
            this.listTasks.Size = new System.Drawing.Size(420, 130);
            this.listTasks.TabIndex = 0;
            // 
            // frmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 276);
            this.Controls.Add(this.listTasks);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "frmTaskList";
            this.Text = "frmTaskList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTasks;
    }
}
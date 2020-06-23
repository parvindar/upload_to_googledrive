namespace WindowsFormsApp3
{
    partial class Form1
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
            this.btn_upload = new System.Windows.Forms.Button();
            this.btn_select_file = new System.Windows.Forms.Button();
            this.lable_file_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(267, 335);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(247, 43);
            this.btn_upload.TabIndex = 0;
            this.btn_upload.Text = "Upload to Google Drive";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_select_file
            // 
            this.btn_select_file.Location = new System.Drawing.Point(279, 167);
            this.btn_select_file.Name = "btn_select_file";
            this.btn_select_file.Size = new System.Drawing.Size(225, 38);
            this.btn_select_file.TabIndex = 1;
            this.btn_select_file.Text = "Select File";
            this.btn_select_file.UseVisualStyleBackColor = true;
            this.btn_select_file.Click += new System.EventHandler(this.btn_select_file_Click);
            // 
            // lable_file_name
            // 
            this.lable_file_name.AutoSize = true;
            this.lable_file_name.Location = new System.Drawing.Point(275, 238);
            this.lable_file_name.Name = "lable_file_name";
            this.lable_file_name.Size = new System.Drawing.Size(0, 20);
            this.lable_file_name.TabIndex = 2;
            this.lable_file_name.Click += new System.EventHandler(this.lable_file_name_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lable_file_name);
            this.Controls.Add(this.btn_select_file);
            this.Controls.Add(this.btn_upload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_select_file;
        private System.Windows.Forms.Label lable_file_name;
    }
}


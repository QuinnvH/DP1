namespace DesignPatterns1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnRunFile = new System.Windows.Forms.Button();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(406, 9);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Openen";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 14);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblFileName.TabIndex = 1;
            // 
            // btnRunFile
            // 
            this.btnRunFile.Location = new System.Drawing.Point(13, 333);
            this.btnRunFile.Name = "btnRunFile";
            this.btnRunFile.Size = new System.Drawing.Size(75, 23);
            this.btnRunFile.TabIndex = 2;
            this.btnRunFile.Text = "Uitvoeren";
            this.btnRunFile.UseVisualStyleBackColor = true;
            this.btnRunFile.Click += new System.EventHandler(this.btnRunFile_Click);
            // 
            // gbInput
            // 
            this.gbInput.Location = new System.Drawing.Point(12, 30);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(200, 100);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 368);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.btnRunFile);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnRunFile;
        private System.Windows.Forms.GroupBox gbInput;
    }
}


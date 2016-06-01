using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public partial class Form1 : Form
    {
        private MainController main;
        public Form1()
        {
            InitializeComponent();
            //Initialize();
            main = new MainController(this);
            btnRunFile.Enabled = false;
        }

        public void AddComponent(Control c) {
            this.tableLayoutPanel1.Controls.Add(c, 0, 1);
        }
        
        public void FileLoadComplete(bool enabled)
        {
            this.btnRunFile.Enabled = enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            main.validFile = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                if(this.tableLayoutPanel1.Controls.Count > 2)
                {
                    this.tableLayoutPanel1.Controls.RemoveAt(2);
                }
                main.filename = openFileDialog1.FileName;
                lblFileName.Text = main.filename;

                main.CheckFile();
            }
        }

        private void btnRunFile_Click(object sender, EventArgs e)
        {
            main.RunCircuit();
        }
    }
}

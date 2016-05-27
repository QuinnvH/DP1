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
        public Circuit circuit { get; set; }
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize() {
            main = new MainController(this);
            btnRunFile.Enabled = false;
        }

        public void AddComponent(Control c) {
            this.tableLayoutPanel1.Controls.Add(c, 0, 1);
        }
        
        public void ChangeEnabled(bool enabled)
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
                main.filename = openFileDialog1.FileName;
                lblFileName.Text = main.filename;

                main.CheckFile();
            }
        }

        private void btnRunFile_Click(object sender, EventArgs e)
        {
            foreach (var item in this.main.circuit.view.Controls)
            {
                foreach (var node in this.circuit.queue)
                {
                    if(node.name == ((CheckBox)item).Text)
                    {
                        node.output = ((CheckBox)item).Checked == true ? 1 : 0;
                    }
                }
            }
            main.RunCircuit();
        }
    }
}

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
            main = new MainController(this);
            this.btnReset.Enabled = false;
            this.btnStep.Enabled = false;
            this.btnRunFile.Enabled = false;
        }

        public void AddComponent(Control c) {
            this.tableLayoutPanel1.Controls.Add(c, 0, 1);
        }
        
        /*
            Zet de knoppen op <enabled>, bijvoorbeeld wanneer een circuit niet goed is.
        */
        public void FileLoadComplete(bool enabled)
        {
            this.btnReset.Enabled = enabled;
            this.btnStep.Enabled = enabled;
            this.btnRunFile.Enabled = enabled;
        }

        /*
            Verantwoordelijk voor het open een FileDialog en het controleren van het bestand nadat de gebruiker deze wil inlezen.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            main.validFile = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
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

        /*
            Verantwoordelijk voor het uitvoeren van het circuit.
        */
        private void btnRunFile_Click(object sender, EventArgs e)
        {
            main.RunCircuit();
        }

        /*
            Verantwoordelijk voor het uitvoeren van een stap van het circuit.
        */
        private void btnStep_Click(object sender, EventArgs e)
        {
            main.RunStep();
        }
        /*
            Verantwoordelijk voor het resetten van het gehele circuit.
        */
        private void btnReset_Click(object sender, EventArgs e)
        {
            main.Reset();
        }
    }
}

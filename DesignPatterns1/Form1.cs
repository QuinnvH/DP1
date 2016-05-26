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
        private Circuit circuit;
        private CircuitBuilder circuitBuilder;
        private string filename;
        private bool validFile = false;
        public Form1()
        {
            InitializeComponent();

            circuitBuilder = new CircuitBuilder();
            btnRunFile.Enabled = false;
        }
        public void ShowOutput()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            validFile = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                filename = openFileDialog1.FileName;
                lblFileName.Text = filename;
            }

            if (File.Exists(filename) && Path.GetExtension(filename) == ".txt")
            {
                try
                {
                    circuitBuilder.LoadCircuit(this.filename);
                    circuit = circuitBuilder.GetPreparedCircuit();
                    validFile = true;
                    btnRunFile.Enabled = true;

                    for(var i = 0; i < circuit.queue.Count; i++)
                    {
                        CheckBox c = new CheckBox();
                        c.Checked = circuit.queue.ElementAt(i).output == 0 ? false : true;
                        c.Top = 15 + i * 20;
                        c.Left = 10;
                        c.Text = circuit.queue.ElementAt(i).name;
                        
                        this.gbInput.Controls.Add(c);
                    }
                    
                }
                catch (Exception exp)
                {
                    validFile = false;
                    btnRunFile.Enabled = false;
                    MessageBox.Show(exp.Message);
                }
            } else {
                validFile = false;
                btnRunFile.Enabled = false;
                MessageBox.Show("Het bestand wat u probeert in te laden bestaat niet of heeft de verkeerde extentie");
            }
        }

        private void btnRunFile_Click(object sender, EventArgs e)
        {
            foreach (var item in this.gbInput.Controls)
            {
                foreach (var node in this.circuit.queue)
                {
                    if(node.name == ((CheckBox)item).Text)
                    {
                        node.output = ((CheckBox)item).Checked == true ? 1 : 0;
                    }
                }
            }
            if (validFile)
            {
                circuit.RunCircuit();
            }
        }
    }
}

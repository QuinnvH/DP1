using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public class MainController
    {
        public Circuit circuit { get; set; }
        private CircuitBuilder circuitBuilder;
        public string filename { get; set; }
        public bool validFile { get; set; }
        private Form1 parent;

        public MainController(Form1 form1) {
            parent = form1;
            circuitBuilder = new CircuitBuilder();
        }
        public void CheckFile()
        {
            if (File.Exists(filename) && Path.GetExtension(filename) == ".txt")
            {
                try
                {
                    circuitBuilder.LoadCircuit(this.filename);
                    circuit = circuitBuilder.GetPreparedCircuit();
                    circuit.view.DrawView();
                    validFile = true;
                    parent.ChangeEnabled(true);

                    parent.AddComponent(circuit.view);
                }
                catch (Exception exp)
                {
                    validFile = false;
                    parent.ChangeEnabled(false);
                    MessageBox.Show(exp.Message);
                }
            }
            else {
                validFile = false;
                parent.ChangeEnabled(false);
                MessageBox.Show("Het bestand wat u probeert in te laden bestaat niet of heeft de verkeerde extentie");
            }
        }
        public void RunCircuit()
        {
            circuit.RunCircuit();
        }
    }
}

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
        private Form1 view;

        public MainController(Form1 form1) {
            view = form1;
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
                    
                    validFile = true;
                    view.FileLoadComplete(validFile);

                    circuit.view.DrawView();

                    view.AddComponent(circuit.view);
                }
                catch (Exception exp)
                {
                    validFile = false;
                    view.FileLoadComplete(validFile);
                    MessageBox.Show(exp.Message);
                }
            }
            else {
                validFile = false;
                view.FileLoadComplete(validFile);
                MessageBox.Show("Het bestand wat u probeert in te laden bestaat niet of heeft de verkeerde extentie");
            }
        }
        public void RunCircuit()
        {
            foreach (var item in this.circuit.view.Controls)
            {
                foreach (var node in this.circuit.queue)
                {
                    if (item.GetType() == typeof(CheckBox) && node.name == ((CheckBox)item).Text)
                    {
                        node.output = ((CheckBox)item).Checked == true ? 1 : 0;
                    }
                }
            }
            circuit.RunCircuit();
        }
    }
}

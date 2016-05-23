using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();

            circuitBuilder = new CircuitBuilder();
            circuitBuilder.LoadCircuit(filename);
            circuit = circuitBuilder.GetPreparedCircuit();

            circuit.RunCircuit();
        }
        public void ShowOutput()
        {

        }
    }
}

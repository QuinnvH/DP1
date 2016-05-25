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
            circuitBuilder.LoadCircuit("C:\\Users\\Paul\\Source\\Repos\\DP1\\DesignPatterns1\\circuit.txt");
            circuit = circuitBuilder.GetPreparedCircuit();

            //circuit.RunCircuit();
        }
        public void ShowOutput()
        {

        }
    }
}

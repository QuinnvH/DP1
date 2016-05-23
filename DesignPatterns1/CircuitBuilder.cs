using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class CircuitBuilder
    {
        private InputReader inputReader = new InputReader();
        private Dictionary<string, BaseNode> nodeList;
        private Circuit circuit;
        public Circuit GetPreparedCircuit()
        {
            return circuit;
        }

        public void LoadCircuit(String filename)
        {
            nodeList = inputReader.ReadFile(filename);
            this.PrepCircuit();
        }

        public void PrepCircuit()
        {
            circuit = new Circuit();

        }
    }
}

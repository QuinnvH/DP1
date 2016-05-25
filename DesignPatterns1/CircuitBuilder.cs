using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class CircuitBuilder
    {
        private InputReader inputReader;
        private Circuit circuit;

        private Factory factory;

        public CircuitBuilder() {
            inputReader = new InputReader();
            circuit = new Circuit();
            factory = new Factory(ref circuit);
        }

        public Circuit GetPreparedCircuit()
        {
            return circuit;
        }

        public void LoadCircuit(String filename)
        {
            Dictionary<string, string> rawNodes = inputReader.RegisterNodes(filename);

            this.PrepCircuit(rawNodes);
        }

        public void PrepCircuit(Dictionary<string, string> rawNodes)
        {
            Dictionary<string, BaseNode> registeredNodes = factory.CreateNodes(rawNodes);

            inputReader.LinkNodes(ref registeredNodes, ref circuit);
        }
    }
}

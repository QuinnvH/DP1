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
        public Circuit circuit;

        private Factory factory;

        public CircuitBuilder() {
            inputReader = new InputReader();
        }

        public Circuit GetPreparedCircuit()
        {
            return circuit;
        }

        /*
            Initialiseert het circuit en de factory.
            Vraagt aan de inputreader om de strings uit te lezen en in een dictionary te zetten.
        */
        public void LoadCircuit(String filename)
        {
            circuit = new Circuit();
            factory = new Factory(ref circuit);
            Dictionary<string, string> rawNodes = inputReader.RegisterNodes(filename);
            this.PrepCircuit(rawNodes);
        }

        /*
            Vraagt aan de factory om de nodes te creeeren op basis van de voorheen doorgegeven dictionary.
            Vraagt aan de inputreader op de gecreeerde nodes onderling met elkaar te linken.
            Voert de ErrorCheck uit.
        */
        public void PrepCircuit(Dictionary<string, string> rawNodes)
        {
            circuit.registeredNodes = factory.CreateNodes(rawNodes);

            inputReader.LinkNodes(ref circuit);

            CircuitErrorCheck(ref circuit.registeredNodes);
        }

        /*
            Checkt door middel van Depth First Search of er een circular depedency in het ciruit zit.
            Loopt daarna door alle nodes heen om te kijken of er Nodes zijn die niet verbonden zijn.
        */
        public void CircuitErrorCheck(ref Dictionary<string, BaseNode> rawNodes)
        {
            //Circular Depedency Check
            Stack<BaseNode> stack = new Stack<BaseNode>();
            List<BaseNode> temp = new List<BaseNode>();

            while (circuit.queue.Count != 0)
            {
                temp.Add(circuit.queue.Dequeue());
            }

            for (int i = 0; i < temp.Count; i++)
            {
                circuit.queue.Enqueue(temp[i]);
                stack.Push(temp[i]);
            }

            while(stack.Count != 0)
            {
                var current = stack.Pop();

                if (current.isVisited > 999)
                {
                    throw new Exception("Er bevindt zich een circulaire verbinding binnen het circuit met een poort zijn naam: " + current.name);
                }
                current.isVisited++;
                
                foreach (var neighbour in current.observers)
                {
                    stack.Push(neighbour);
                }
            }

            //Unconnected Pins Check
            foreach (var item in rawNodes)
            {
                if (item.Value.GetType() != typeof(OutputNode) && item.Value.observers.Count == 0)
                {
                    throw new Exception("Er bevindt zich een niet verbonden poort binnen het circuit met de naam: " + item.Key);
                }
            }

            this.circuit.ResetVisited();
        }
    }
}

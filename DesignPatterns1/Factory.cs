using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class Factory
    {
        Dictionary<string, BaseNode> options;

        public Factory()
        {
            InputNode low = new InputNode(0);
            InputNode high = new InputNode(1);

            options = new Dictionary<string, BaseNode>();

            RegisterNode("AND", new AndNode());
            RegisterNode("OR", new OrNode());
            RegisterNode("INPUT_HIGH", low);
            RegisterNode("INPUT_LOW", high);
            RegisterNode("NAND", new NandNode());
            RegisterNode("NOR", new NorNode());
            RegisterNode("NOT", new NotNode());
            RegisterNode("PROBE", new OutputNode());
            RegisterNode("XOR", new XorNode());
        }

        public void RegisterNode(string name, BaseNode node)
        {
            options.Add(name, node);
        }

        internal Dictionary<string, BaseNode> CreateNodes(Dictionary<string, string> rawNodes)
        {
            Dictionary<string, BaseNode> returnval = new Dictionary<string, BaseNode>();

            foreach(var node in rawNodes)
            {
                if(!options.ContainsKey(node.Value)) throw new ArgumentException("Ongeldige node registratie op node: " + node.Key + " met value: " + node.Value);
                returnval.Add(node.Key, options[node.Value].Clone());
            }

            return returnval;
        }
    }
}

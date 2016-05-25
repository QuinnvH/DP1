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
        Circuit c;

        public Factory(ref Circuit c)
        {
            this.c = c;
            options = new Dictionary<string, BaseNode>();

            RegisterNode("AND", new AndNode(ref c));
            RegisterNode("OR", new OrNode(ref c));
            RegisterNode("INPUT_HIGH", new InputNode(ref c, 1));
            RegisterNode("INPUT_LOW", new InputNode(ref c, 0));
            RegisterNode("NAND", new NandNode(ref c));
            RegisterNode("NOR", new NorNode(ref c));
            RegisterNode("NOT", new NotNode(ref c));
            RegisterNode("PROBE", new OutputNode(ref c));
            RegisterNode("XOR", new XorNode(ref c));
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

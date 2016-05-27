using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public class Circuit
    {
        public Queue<BaseNode> queue = new Queue<BaseNode>();
        public CircuitView view { get; set; }

        public Circuit() {
            view = new CircuitView(this);
        }

        internal void AddToQueue(BaseNode baseNode)
        {
            queue.Enqueue(baseNode);
        }

        internal void RunCircuit()
        {
            BaseNode node = null;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.Execute();
            }

            if (node.GetType() != typeof(OutputNode)){
                bool check = false;
            }
        }
    }
}

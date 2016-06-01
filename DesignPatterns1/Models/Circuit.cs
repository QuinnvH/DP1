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
        public List<BaseNode> startNodes = new List<BaseNode>();
        public Dictionary<string, BaseNode> registeredNodes = new Dictionary<string, BaseNode>();
        public CircuitView view { get; set; }

        public Circuit() {
            view = new CircuitView(this);
        }
        public void AddToQueue(BaseNode baseNode)
        {
            queue.Enqueue(baseNode);
        }

        public void RunCircuit()
        {
            BaseNode node = null;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.Execute();
            }
        }

        public void ResetCircuit()
        {
            this.ResetVisited();
            foreach (var item in this.registeredNodes)
            {
                item.Value.updateCount = 0;
                item.Value.output = 0;
            }
            this.queue = new Queue<BaseNode>(this.startNodes);
        }
        public void ResetVisited()
        {
            foreach (var item in this.registeredNodes)
            {
                item.Value.isVisited = 0;
            }
        }
    }
}

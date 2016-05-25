using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class Circuit
    {
        Queue<BaseNode> queue = new Queue<BaseNode>();

        internal void AddToQueue(BaseNode baseNode)
        {
            queue.Enqueue(baseNode);
        }

        internal void RunCircuit()
        {
            while(queue.Count > 0)
            {
                BaseNode node = queue.Dequeue();
                node.Execute();
            }
        }
    }
}

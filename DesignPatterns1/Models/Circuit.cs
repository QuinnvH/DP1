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

        /*
          Voert het circuit uit net zolang totdat de Queue niet leeg is.
        */
        public void RunCircuit()
        {
            BaseNode node = null;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.Execute();
            }
        }
        /*
          Zet alle waardes van het Circuit weer naar de orginele waardes zoals deze zijn ingelezen.
      */
        public void ResetCircuit()
        {
            this.ResetVisited();
            foreach (var item in this.registeredNodes)
            {
                item.Value.updateCount = 0;
                if(item.Value.GetType() != typeof(InputNode))
                {
                    item.Value.output = 0;
                }
                item.Value.drawObserver.NotifyReset();
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
        /*
          Voert een enkele stap uit van het Circuit.
      */
        internal void RunStep()
        {
            BaseNode node = null;
            if (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.Execute();
            } else
            {
                MessageBox.Show("Het circuit is afgelopen. Druk op reset om overnieuw te beginnen.");
            }
        }
    }
}

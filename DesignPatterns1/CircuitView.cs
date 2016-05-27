using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public class CircuitView : GroupBox
    {
        private Circuit model;
        public CircuitView(Circuit model)
        {
            this.model = model;
            this.Dock = DockStyle.Fill;

            this.Text = "";
        }

        public void DrawView()
        {
            for (var i = 0; i < model.queue.Count; i++)
            {
                CheckBox c = new CheckBox();
                c.AutoSize = true;
                c.Checked = model.queue.ElementAt(i).output == 0 ? false : true;
                c.Top = 15;
                c.Left = 10 + i * 75;
                c.Text = model.queue.ElementAt(i).name;

                this.Controls.Add(c);
            }

            Queue<BaseNode> q = new Queue<BaseNode>();
            List<BaseNode> visited = new List<BaseNode>();
            int row = 0;
            int col = 0;
            int marginTop = 10;
            int marginLeft = 10;

            foreach(BaseNode item in model.queue)
            {
                q.Enqueue(item);
            }

            while(q.Count > 0)
            {
                BaseNode node = q.Dequeue();
                if (visited.Contains(node))
                    continue;

                foreach(BaseNode item in node.observers)
                {
                    if (!visited.Contains(item))
                        q.Enqueue(item);
                }

                visited.Add(node);

                NodeView view = new NodeView(node);

                view.Top = 50 + marginTop + row * view.Height;
                view.Left = marginLeft + col * view.Width;
                row++;

                if(row > 5)
                {
                    col++;
                    row = 0;
                }

                this.Controls.Add(view);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public class CircuitView : Panel
    {
        private Circuit model;
        public CircuitView(Circuit model)
        {
            this.model = model;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.HorizontalScroll.Enabled = true;
            this.HorizontalScroll.Visible = true;
            this.VerticalScroll.Enabled = true;
            this.VerticalScroll.Visible = true;
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
                c.CheckedChanged += C_CheckedChanged;
                this.Controls.Add(c);
            }

            Queue<BaseNode> q = new Queue<BaseNode>();
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
                if (node.isVisited > 0)
                    continue;

                foreach(BaseNode item in node.observers)
                {
                    if (node.isVisited == 0)
                        q.Enqueue(item);
                }

                node.isVisited++;

                NodeView view = new NodeView(node);
                view.subject = node;
                node.AttachDrawObserver(view);

                view.Top = 50 + marginTop + row * 125;
                view.Left = marginLeft + col * 125;
                row++;

                if(row > 5)
                {
                    col++;
                    row = 0;
                }

                this.Controls.Add(view);
            }
            this.model.ResetVisited();
        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {
            model.registeredNodes[((CheckBox)sender).Text].output = ((CheckBox)sender).Checked == true ? 1 : 0;
            model.registeredNodes[((CheckBox)sender).Text].NotifyDraw();
        }
    }
}

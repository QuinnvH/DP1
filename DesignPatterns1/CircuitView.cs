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
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;

namespace DesignPatterns1
{
    public class NodeView : FlowLayoutPanel
    {
        private BaseNode model;
        private Label Name;
        private Label Linked;
        private Label Output;
        public BaseNode subject { get; set; }
        public NodeView(BaseNode model)
        {
            this.FlowDirection = FlowDirection.TopDown;
            this.BackColor = System.Drawing.Color.Green;
            this.Padding = new Padding(5);
            this.model = model;
            this.Width = 100;
            this.Height = 100;

            Name = new Label();
            Linked = new Label();
            Output = new Label();

            this.Controls.Add(Name);
            this.Controls.Add(Linked);
            this.Controls.Add(Output);
        }
        public void Draw()
        {
            Name.Text = "Name: ";
            Linked.Width = this.Width;
            Linked.AutoSize = true;
            Output.Padding = new Padding(0, 10, 0, 0);
            Output.Text = "Output: ";

            Name.Text += model.name;
            Output.Text += model.output.ToString();

            string temp = "";
            for (int i = 0; i < model.observers.Count; i++)
            {
                temp += model.observers[i].name;
                if (i != model.observers.Count - 1)
                {
                    temp += ", ";
                }
            }

            Linked.Text = temp;
        }
        public void DrawOutput()
        {
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Output.Text = "Output: " + model.output.ToString();
        }
        public void NotifyReset()
        {
            this.BackColor = System.Drawing.Color.Green;
            this.Output.Text = "Output: " + model.output.ToString();
        }
    }
}
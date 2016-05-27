using System.Windows.Forms;

namespace DesignPatterns1
{
    public class NodeView : Label
    {
        private BaseNode model;
        public NodeView(BaseNode model)
        {
            this.model = model;
            this.Text = model.name;
        }
    }
}
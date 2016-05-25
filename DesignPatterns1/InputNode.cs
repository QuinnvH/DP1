using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class InputNode : BaseNode
    {
        public int value { get; set; }

        public InputNode()
        {

        }

        public InputNode(int val)
        {
            this.value = val;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public BaseNode Clone()
        {
            return new InputNode() { };
        }
    }
}

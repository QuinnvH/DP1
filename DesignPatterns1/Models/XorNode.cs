using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class XorNode : BaseNode
    {
        public XorNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            this.output = subjects[0].output == subjects[1].output ? 0 : 1;
            this.Notify();
            this.NotifyDraw();
        }

        public override BaseNode Clone(string param)
        {
            return new XorNode(ref c) { name = param };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class AndNode : BaseNode
    {
        public AndNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            this.output = subjects[0].output == 1 && subjects[1].output == 1 ? 1 : 0;
            this.Notify();
            this.NotifyDraw();
        }

        public override BaseNode Clone(string param)
        {
            return new AndNode(ref c) { name = param };
        }
    }
}

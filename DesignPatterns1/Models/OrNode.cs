using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class OrNode : BaseNode
    {
        public OrNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            this.output = subjects[0].output == 0 && subjects[1].output == 0 ? 0 : 1;
            this.Notify();
        }

        public override BaseNode Clone(string param)
        {
            return new OrNode(ref c) { name = param };
        }
    }
}

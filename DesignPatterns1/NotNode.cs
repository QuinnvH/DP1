using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class NotNode : BaseNode
    {
        public NotNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            this.output = subjects[0].output == 0 ? 1 : 0;
            this.Notify();
        }

        public override BaseNode Clone(string param)
        {
            return new NotNode(ref c) { name = param };
        }
    }
}

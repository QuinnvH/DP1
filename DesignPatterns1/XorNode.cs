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
            Console.WriteLine("XOR");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new XorNode(ref c) { };
        }
    }
}

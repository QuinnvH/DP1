using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class NorNode : BaseNode
    {
        public NorNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("NOR");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new NorNode(ref c) { };
        }
    }
}

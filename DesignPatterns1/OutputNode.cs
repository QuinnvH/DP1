using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class OutputNode : BaseNode
    {
        public OutputNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("PROBE");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new OutputNode(ref c) { };
        }
    }
}

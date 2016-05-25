using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class NandNode : BaseNode
    {
        public NandNode(ref Circuit c) : base(ref c)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("NAND");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new NandNode(ref c) { };
        }
    }
}

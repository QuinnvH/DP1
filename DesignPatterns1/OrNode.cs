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
            Console.WriteLine("OR");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new OrNode(ref c) { };
        }
    }
}

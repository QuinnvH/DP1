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
            Console.WriteLine("AND");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new AndNode(ref c) {  };
        }
    }
}

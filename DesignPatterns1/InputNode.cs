using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class InputNode : BaseNode
    {
        public InputNode(ref Circuit c) : base(ref c)
        {
        }

        public InputNode(ref Circuit c, int val) : base(ref c)
        {
            this.output = val;
        }

        public override void Execute()
        {
            Console.WriteLine("INPUT: " + output);
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new InputNode(ref c) { output = this.output };
        }
    }
}

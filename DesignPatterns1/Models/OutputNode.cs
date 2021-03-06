﻿using System;
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
            this.output = subjects[0].output;
            Console.WriteLine(subjects[0].output);
            this.Notify();
            this.NotifyDraw();
        }

        public override BaseNode Clone(string param)
        {
            return new OutputNode(ref c) { name = param };
        }
    }
}

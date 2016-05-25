﻿using System;
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
            Console.WriteLine("NOT");
            this.Notify();
        }

        public override BaseNode Clone()
        {
            return new NotNode(ref c) { };
        }
    }
}

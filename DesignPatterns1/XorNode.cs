﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class XorNode : BaseNode
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public BaseNode Clone()
        {
            return new XorNode() { };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class Factory
    {
        internal Dictionary<string, BaseNode> CreateNodes(Dictionary<string, string> rawNodes)
        {
            return new Dictionary<string, BaseNode>();
        }
    }
}

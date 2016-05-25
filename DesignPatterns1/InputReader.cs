using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class InputReader
    {
        private String filename;
        public Dictionary<string, string> RegisterNodes(String filename)
        {
            this.filename = filename;

            Dictionary<string, string> temp = new Dictionary<string, string>();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(this.filename);

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
            }

            file.Close();

            return temp;
        }

        public void LinkNodes(Dictionary<string, BaseNode> rawNodes)
        {
            
        }
    }
}

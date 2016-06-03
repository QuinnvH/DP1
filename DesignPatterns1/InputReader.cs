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

        /*
           Regristreert de Nodes door door de file heen te lopen tot aan de regelbreek en ze in een dictionary te stoppen.
       */
        public Dictionary<string, string> RegisterNodes(String filename)
        {
            this.filename = filename;

            Dictionary<string, string> returnval = new Dictionary<string, string>();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(this.filename);

            while ((line = file.ReadLine()) != null)
            {
                if(line == "") break;
                if (line.Length > 0 && line[0] != '#')
                {
                    line = line.Replace("\t", "").Replace(" ", "").Replace(";", "");
                    string[] temp = line.Split(':');
                    returnval.Add(temp[0], temp[1]);
                }
            }

            file.Close();

            return returnval;
        }

        /*
          Verbind de Nodes onderling door elkaar op basis van de Nodes in het Circuit.
        */
        public void LinkNodes(ref Circuit c)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(this.filename);
            bool breakLineFound = false;

            while ((line = file.ReadLine()) != null)
            {
                if (line == "") breakLineFound = true;
                if (breakLineFound && line.Length > 0 && line[0] != '#')
                {
                    line = line.Replace("\t", "").Replace(" ", "").Replace(";", "");
                    string[] pair = line.Split(':');
                    string key = pair[0];
                    string[] values = pair[1].Split(',');

                    if (c.registeredNodes[key].GetType() == typeof(InputNode))
                    {
                        c.AddToQueue(c.registeredNodes[key]);
                        c.startNodes.Add(c.registeredNodes[key]);
                    }

                    foreach(var val in values)
                    {
                        c.registeredNodes[key].AttachObserver(c.registeredNodes[val]);
                        c.registeredNodes[val].AttachSubject(c.registeredNodes[key]);
                    }
                }
            }

            file.Close();
        }
    }
}

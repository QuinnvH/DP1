﻿using System;
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

        public void LinkNodes(ref Dictionary<string, BaseNode> rawNodes, ref Circuit c)
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

                    if (rawNodes[key].GetType() == typeof(InputNode))
                    {
                        c.AddToQueue(rawNodes[key]);
                    }

                    foreach(var val in values)
                    {
                        rawNodes[key].AttachObserver(rawNodes[val]);
                        rawNodes[val].AttachSubject(rawNodes[key]);
                    }
                }
            }

            file.Close();
        }
    }
}

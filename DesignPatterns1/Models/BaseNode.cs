using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public abstract class BaseNode
    {
        // Properties
        protected Circuit c;
        public int output { get; set; }
        public int isVisited { get; set; }
        public string name { get; set; }
        protected int updateCount;
        public List<BaseNode> subjects { get; set; }
        public List<BaseNode> observers { get; set; }

        // Constructor
        public BaseNode(ref Circuit c)
        {
            this.c = c;
            this.updateCount = 0;
            this.isVisited = 0;
            subjects = new List<BaseNode>();
            observers = new List<BaseNode>();
        }
        
        // Functions
        public abstract void Execute();
        public void Update()
        {
            updateCount++;
            if (updateCount >= subjects.Count)
            {
                c.AddToQueue(this);
            }
        }
        public void AttachObserver(BaseNode observer)
        {
            observers.Add(observer);
        }
        public void AttachSubject(BaseNode subject)
        {
            subjects.Add(subject);
        }
        public void Notify()
        {
            foreach (BaseNode o in observers)
            {
                o.Update();
            }
        }
        public abstract BaseNode Clone(string name);
    }
}

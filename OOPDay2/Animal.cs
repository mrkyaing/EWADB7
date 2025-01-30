using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oopday2
{
    public class Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        private int ageinMonth;
        public int AgeInMonth
        {
            get { return ageinMonth; }
            set { ageinMonth = value; }
        }
        
        public void Speak()=>Console.WriteLine($"{name} can talk and month is {AgeInMonth}");

        public virtual void Eat()=>Console.WriteLine("eating something");
    }
}
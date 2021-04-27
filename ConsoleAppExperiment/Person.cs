using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExperiment
{
    public class Person
    {
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Person Parent { get; set; }

        public Person(string firstName, string lastName, int age, Person parent = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Parent = parent;
        }

        //public Person()
        //{

        //}

    }
}

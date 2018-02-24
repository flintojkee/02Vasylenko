using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Vasylenko
{ 
    public class PersonRepository
    {
        private static List<Person> persons = new List<Person>();

     
        internal void Add(Person person)
        {
            persons.Add(person);
        }
    }
}

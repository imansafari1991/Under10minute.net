using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample
{
    public class ImmutablePerson
    {
        private readonly string _name;

        public ImmutablePerson(string name)
        {
            _name = name;
        }

        public string Name=> _name;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return "My name is '" + Name + "' and I am " + Age + " years old.";
        }
        public abstract float Height { get; }

        public abstract PersonType PersonType { get; }

        public string PersonTypeName { get { return PersonType.ToString(); } }
    }
}

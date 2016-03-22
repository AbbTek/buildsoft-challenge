using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public class PersonList
    {
        public int TotalPeople { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public List<Person> List { get; set; }
    }
}

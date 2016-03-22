using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public class PersonListResult
    {
        public int TotalPeople { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public List<Person> List { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public int AverageAge { get; set; }
    }
}

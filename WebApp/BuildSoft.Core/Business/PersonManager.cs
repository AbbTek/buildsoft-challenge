using BuildSoft.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Business
{
    public static class PersonManager
    {
        private static readonly Random _random = new Random();
        public static List<Person> Init()
        {
            var list = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                var person = (Person)null;
                var type = (PersonType)_random.Next(1, 5);
                var age = _random.Next(1, 99);
                var name = "Person #" + i.ToString();
                switch (type)
                {
                    case PersonType.Angle:
                        person = new Angle() { Age = age, Name = name };
                        break;
                    case PersonType.Asian:
                        person = new Asian() { Age = age, Name = name };
                        break;
                    case PersonType.Jute:
                        person = new Jute() { Age = age, Name = name };
                        break;
                    case PersonType.Saxon:
                        person = new Saxon() { Age = age, Name = name };
                        break;
                }
                list.Add(person);
            }
            return list;
        }
    }
}

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
        private static List<Person> _list = null;
        private static object _lock = new object();
        private const int TOTAL_PEOPLE = 10000;
        static PersonManager()
        {
            Init();
        }
        private static void Init()
        {
            if (_list == null)
            {
                lock (_lock)
                {
                    var list = new List<Person>();
                    for (int i = 0; i < TOTAL_PEOPLE; i++)
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
                    _list = list.OrderBy(x => x.Age).ToList();
                }
            }
        }
        private static Type GetType(PersonType type)
        {
            switch (type)
            {
                case PersonType.Angle:
                    return typeof(Angle);
                case PersonType.Asian:
                    return typeof(Asian);
                case PersonType.Jute:
                    return typeof(Jute);
                case PersonType.Saxon:
                    return typeof(Saxon);
                default:
                    return null;
            }
        }

        public static PersonList GetPeople(uint page, uint max, PersonType type)
        {
            var list = type == PersonType.None ? _list : _list.Where(x => x.GetType() == GetType(type)).ToList();

            var result = new PersonList();
            var index = page == 1 ? 0 : Convert.ToInt32((page - 1) * max);
            var count = index + max > list.Count ? list.Count - index : Convert.ToInt32(max);
            result.List = list.GetRange(index,  count);
            result.ItemsPerPage = Convert.ToInt32(max);
            result.TotalPeople = list.Count();
            result.CurrentPage = Convert.ToInt32(page);
            return result;
        }
    }
}

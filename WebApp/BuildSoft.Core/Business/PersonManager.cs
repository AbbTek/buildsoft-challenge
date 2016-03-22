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

        public static void Restart()
        {
            lock (_lock)
            {
                _list = null;
            }
            Init();
        }

        public static PersonListResult GetPeople(uint page, uint max, PersonType type)
        {
            var list = type == PersonType.None ? _list : _list.Where(x => x.GetType() == GetType(type)).ToList();

            var result = new PersonListResult();
            var index = page == 1 ? 0 : Convert.ToInt32((page - 1) * max);
            var count = index + max > list.Count ? list.Count - index : Convert.ToInt32(max);
            
            if (count < 0)
            {
                index = 0;
                page = 1;
                count = Convert.ToInt32(max);
            }

            result.List = list.GetRange(index,  count);
            result.ItemsPerPage = Convert.ToInt32(max);
            result.TotalPeople = list.Count();
            result.CurrentPage = Convert.ToInt32(page);
            result.MaxAge = list.Max(x => x.Age);
            result.MinAge = list.Min(x => x.Age);
            result.AverageAge = Convert.ToInt32(list.Average(x => x.Age));
            return result;
        }
   
        public static void AddYear(int years)
        {
            lock (_lock)
            {
                _list = _list.Select(x => AddYear(x, years)).ToList();
            }   
        }

        public static Dictionary<PersonType, int> GetConsolidatedData()
        {
            lock (_lock)
            {
                return _list.GroupBy(x => x.PersonType)
                    .Select(lg => new { Key = lg.Key, Count = lg.Count() })
                    .ToDictionary(d => d.Key, d=>d.Count);
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

        private static Person AddYear(Person person, int years)
        {
            person.Age += years;
            return person;
        }
    }
}

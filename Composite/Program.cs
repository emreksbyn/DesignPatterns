using System;
using System.Collections;
using System.Collections.Generic;

/*
    Nesneler arasi hiyerarsi ve bu hiyerarsik nesnelere istedigim zaman ulasabilmek demektir.
 */
namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emre = new Employee { Name = "Emre" };

            Employee ahmet = new Employee { Name = "Ahmet" };
            emre.AddSubordinate(ahmet);

            Employee mehmet = new Employee { Name = "Mehmet" };
            emre.AddSubordinate(mehmet);

            Employee can = new Employee { Name = "Can" };
            ahmet.AddSubordinate(can);

            Contractor cem = new Contractor { Name = "Cem" };
            mehmet.AddSubordinate(cem);

            Console.WriteLine(emre.Name);
            foreach (Employee manager in emre)
            {
                Console.WriteLine("  " + manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    " + employee.Name);
                }
            }
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                // Enumerable yani itare edilebilir donmesi icin yield keywordu kullanilir.
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
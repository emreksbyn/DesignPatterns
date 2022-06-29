using System;

/*
    Amac nesne uretme maliyetlerini minimize etmektir. Her zaman bu deseni kullanamayiz ihtiyaclar dahilinde kullanilir.
 */
namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { Id = 1, FirstName = "Emre", LastName = "Kisaboyun", City = "Zonguldak" };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Emree";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadLine();
        }

        // Prototype nesnemiz.
        public abstract class Person
        {
            public abstract Person Clone();

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Customer : Person
        {
            public string City { get; set; }

            public override Person Clone()
            {
                // Shallow copy
                return (Person)MemberwiseClone();
            }
        }
        public class Employee : Person
        {
            public decimal Salary { get; set; }

            public override Person Clone()
            {
                // Shallow copy
                return (Person)MemberwiseClone();
            }
        }
    }
}

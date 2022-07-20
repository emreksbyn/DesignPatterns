using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2022CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalculatorBase = new Before2022CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2022CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2022");
        }
    }
    class After2022CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2022");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();
        }
    }
}
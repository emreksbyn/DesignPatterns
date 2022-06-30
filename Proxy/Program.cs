using System;
using System.Threading;

/*
    Bu DP' yi cache' leme sistemine benzetebiliriz. Bir sinif ve bu sinifin cagirdigi bir islem var. Ilk kez cagirdiginde mecburen o islem yapilacak. Fakat 2. kez cagirildiginda daha oncekini kullanma 
 */
namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditManager manager = new CreditManager();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            CreditManagerProxy creditManagerProxy = new CreditManagerProxy();
            Console.WriteLine(creditManagerProxy.Calculate());
            Console.WriteLine(creditManagerProxy.Calculate());
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}
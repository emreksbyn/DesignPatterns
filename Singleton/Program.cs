using System;

/*
  Bir nesne orneginden sadece bir kere uretilip ve bu nesne orneginin her zaman kullanilmasini saglayan yapidir.
    -> Site ziyaretci sayisi gosterimi
    -> Business katmanindaki XManager nesnesi ( Add, Update, Delete ..) sadece bir kere uretip kullanima acilmasi gerekir. Cunku ayni isi farklı nesnelerde yapmamiz mantıksız ve maliyetlidir.
  Bir nesne zaten uygulama boyunca sadece bir kere kullanilacaksa bunu Singleton DP yapmamiz Mantiksiz olur.
 */
namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Asagidaki gibi bir kullanıma izin vermez.
            //CustomerManager customerManager = new CustomerManager();

            // Bu sekilde kullandirir.
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        // Once bu class in private bir ctor u olusturulur.
        // Bu sayede disaridan erisim engellenir.
        private static CustomerManager _customerManager;
        // Thread Safe Singleton yapmak istiyorsak bir lock nesnesi olusturmamiz gerekir.
        static object _lockObject = new object();
        private CustomerManager()
        {

        }
        // Bu nesneyi olusturacak bir metoda ihtiyacimiz var. Bunuda static olarak yazariz.
        // Varsa olanı ver yoksa instance al ve ver.
        public static CustomerManager CreateAsSingleton()
        {
            // ?? sonrasındaki kısım eger null ise demek oluyor.
            //return _customerManager ?? (_customerManager = new CustomerManager());

            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                } 
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved.");
        }
    }
}
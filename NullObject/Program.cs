using System;

// Manager nesnesi test ederken Log islemini devre disi birakmak isteyebiliriz. Bunun icin loglama islemi yapmayan bir log sinifi olustururuz ( StubLogger ). Hata almadan calismamizi saglar. Sistem log nesnesi var sanir ama islevi yoktur.
namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loglama yapilan
            CustomerManager customerManager1 = new CustomerManager(new NLogLogger());
            customerManager1.Save();

            // Loglama yapilmayan
            CustomerManager customerManager2 = new CustomerManager(StubLogger.GetLogger());
            customerManager2.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private readonly ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            this._logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLogLogger");
        }
    }

    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();
        private StubLogger() { }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }

        public void Log()
        {
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}
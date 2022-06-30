using System;

/*
    Farkli sistemlerin kendi sistemlerimize entegre edilmesi durumunda kendi sistemimizin bozulmadan diger sistemin bizim sistemimizmis gibi davranmasini saglar. 
*/
namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EkLogger());
            productManager.Save();
            ProductManager productManager2 = new ProductManager(new Log4NetAdapter());
            productManager2.Save();
        }
    }

    class ProductManager
    {
        private readonly ILogger _logger;

        public ProductManager(ILogger logger)
        {
            this._logger = logger;
        }
        public void Save()
        {
            _logger.Log("Product Data");
            Console.WriteLine("Saved.");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EkLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with EkLogger, {0}", message);
        }
    }

    // Nuget'den indirdigimizi varsay. Disardan mudahale edilmiyor. Yani ILogger' i implemente edemiyoruz.
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
using System;

/*
    Birbirleri ile iliskili nesneleri olusturmak icin bir arayuz saglar ve alt siniflarin hangi sinifin ornegi olusturacagina olanak saglar.
    Buradaki amac istemci tarafından birbirleri ile iliskili nesnelerin olusturulma anını soyutlamak, istemci hangi sinif ornegini alabilecegini bilebilir ama olusturulma detaylari bilmez. Detaylar yani nesnenin nasıl olusturulacagi soyutlanir. Ornegin olusturulan sinifin Singleton olarak olusturulmasi gibi.
 */
namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager1 = new CustomerManager(new LoggerFactoryA());
            customerManager1.Save();
            CustomerManager customerManager2 = new CustomerManager(new LoggerFactoryB());
            customerManager2.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactoryA : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            return new EkLogger();
        }
    }
    public class LoggerFactoryB : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EkLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EkLogger.");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger.");
        }
    }

    public class CustomerManager
    {
        private readonly ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            this._loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved.");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
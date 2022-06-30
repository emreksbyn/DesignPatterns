using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new CrossCuttingConcernsFacade());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged.");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached.");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked.");
        }
    }

    // Sonradan Validation islemi icin eklemeler yapildiginda sorun cikmamasi saglandi.
    interface IValidate
    {
        void Validate();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated.");
        }
    }

    class CustomerManager
    {
        private readonly CrossCuttingConcernsFacade _crossCuttingConcernsFacade;

        //private readonly ILogging _logging;
        //private readonly ICaching _caching;
        //private readonly IAuthorize _authorize;

        public CustomerManager(CrossCuttingConcernsFacade crossCuttingConcernsFacade)
        {
            this._crossCuttingConcernsFacade = crossCuttingConcernsFacade;
            //this._logging = logging;
            //this._caching = caching;
            //this._authorize = authorize;
        }

        public void Save()
        {
            _crossCuttingConcernsFacade.Logging.Log();
            _crossCuttingConcernsFacade.Caching.Cache();
            _crossCuttingConcernsFacade.Authorize.CheckUser();
            _crossCuttingConcernsFacade.Validate.Validate();

            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validation();
        }
    }
}
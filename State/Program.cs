using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);
            DeleteState deleted = new DeleteState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState().ToString());
            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }
    
    class DeleteState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
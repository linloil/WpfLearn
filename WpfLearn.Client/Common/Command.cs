using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;


namespace WpfLearn.Client
{
    public class Command : Command<object>
    {
        public Command(Func<object, bool> canExecute, Action<object> execute)
            : base(canExecute, execute)
        {
        }


        public Command(Action<object> execute) : base(execute)
        {
        }
    }



    public class Command<T> : ICommand
    {
        private readonly Func<T, bool> canExecute;
        private readonly Action<T> execute;


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public Command(Action<T> execute)
            : this(_ => true, execute)
        {
        }


        public Command(Func<T, bool> canExecute, Action<T> execute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecute((T)parameter);
        }


        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}

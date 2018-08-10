using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalizeBuilder.src
{
    public class RelayCommand : ICommand
    {
        //Fields
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _can_execute;

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Constructors
        public RelayCommand(Action<object> execute, Func<object, bool> can_execute = null)
        {
            _execute = execute;
            _can_execute = can_execute;
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _can_execute == null || _can_execute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

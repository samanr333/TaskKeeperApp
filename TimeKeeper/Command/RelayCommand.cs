using System;
using System.Windows.Input;

namespace TimeKeeper.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanExecute { get; set; }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}

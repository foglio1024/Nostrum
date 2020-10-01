using System;
using System.Windows.Input;

namespace Nostrum
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<object, bool> canExecute = null) 
        {
            _execute = _ => execute();
            _canExecute = canExecute;
        }
    }
    /// <summary>
    /// A RelayCommand which allows you to specify command parameter type.
    /// </summary>
    public class RelayCommand<ParameterType> : RelayCommand 
    {
        public RelayCommand(Action<ParameterType> execute, Func<object, bool> canExecute = null) 
            : base(o =>
            {
                if (o is ParameterType p)
                    execute(p);
                else 
                    execute(default);
            }, canExecute) { }
    }
}

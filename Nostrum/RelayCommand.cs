using System;
using System.Windows.Input;

namespace Nostrum
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
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
    public class RelayCommand<ParameterType> : ICommand
    {
        private readonly Action<ParameterType> _execute;
        private readonly Func<object, bool> _canExecute;
        private readonly bool _checkParamType;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_checkParamType)
            {
                if (!(parameter is ParameterType p)) return;
                _execute(p);
            }
            else
            {
                _execute((ParameterType) parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute">the Action te executed</param>
        /// <param name="canExecute">the Func to be executed to check if the command can be executed</param>
        /// <param name="checkParamType">if true, avoids executing the command if the parameter cannot be casted to ParameterType</param>
        public RelayCommand(Action<ParameterType> execute, Func<object, bool> canExecute = null, bool checkParamType = true)
        {
            _execute = execute;
            _canExecute = canExecute;
            _checkParamType = checkParamType;
        }
    }
}

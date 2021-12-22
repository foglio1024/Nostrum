using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nostrum.WPF
{
    /// <summary>
    /// A generic <see cref="ICommand"/> implementation.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Delegate _execute;
        private readonly Func<object?, bool>? _canExecute;

        /// <summary>
        /// Called when checking if the command can be executed. Executes the <see cref="Func{object, bool}"/> passed via the constructor, if any.
        /// </summary>
        /// <param name="parameter">a generic parameter</param>
        /// <returns>true if the command can be executed, false otherwise</returns>
        public virtual bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command by calling the <see cref="Action"/> passed via the constructor.
        /// </summary>
        /// <param name="parameter"></param>
        public virtual void Execute(object? parameter)
        {
            _execute.DynamicInvoke(parameter);
        }

        /// <summary>
        /// Event fired when <see cref="CanExecute"/> result changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Constructor in which the <see cref="Execute"/> method parameter is specified.
        /// </summary>
        /// <param name="execute">the delegate to call when executing the command</param>
        /// <param name="canExecute">the delegate to call when checking if the command can be executed</param>
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor in which the <see cref="Execute"/> method parameter is specified and the method returns a <see cref="Task"/>.
        /// </summary>
        /// <param name="execute">the delegate to call when executing the command</param>
        /// <param name="canExecute">the delegate to call when checking if the command can be executed</param>
        public RelayCommand(Func<object?, Task> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor in which the <see cref="Execute"/> is called with no parameters.
        /// </summary>
        /// <param name="execute">the delegate to call when executing the command</param>
        /// <param name="canExecute">the delegate to call when checking if the command can be executed</param>
        public RelayCommand(Action execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor in which the <see cref="Execute"/> is called asynchronously with no parameters and returns a <see cref="Task"/>.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Func<Task> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
    }

    /// <summary>
    /// A RelayCommand which allows you to specify command parameter type.
    /// </summary>
    public class RelayCommand<TParameter> : RelayCommand
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="execute">the delegate to call when executing the command</param>
        /// <param name="canExecute">the delegate to call when checking if the command can be executed</param>
        public RelayCommand(Action<TParameter?> execute, Func<object?, bool>? canExecute = null)
            : base(o =>
            {
                if (o is TParameter p) execute(p);
                else execute(default);
            }, canExecute)
        { }
    }
}

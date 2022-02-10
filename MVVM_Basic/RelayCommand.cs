using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Basic
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;
        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<T> execute) : this(execute, (parameter) => true) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public void Execute(object parameter)
            => execute((T)parameter);

        public bool CanExecute(object parameter)
            => canExecute != null && canExecute((T)parameter);

        public void OnCanExecuteChanged()
            => CanExecuteChangedInternal?.Invoke(this, EventArgs.Empty);

    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action execute) : this(execute, () => true) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public void Execute(object parameter)
           => execute();

        public bool CanExecute(object parameter)
            => canExecute != null && canExecute();       

        public void OnCanExecuteChanged()
            => CanExecuteChangedInternal?.Invoke(this, EventArgs.Empty);
    }
}

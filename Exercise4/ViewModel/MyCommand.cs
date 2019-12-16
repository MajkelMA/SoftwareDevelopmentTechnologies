using System;
using System.Windows.Input;

namespace ViewModel
{
    public class MyCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public MyCommand(Action execute) : this(execute, null) { }
        public MyCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //if (this._canExecute == null)
            //    return true;
            //if (parameter == null)
            //    return this._canExecute();
            //return this._canExecute();
            return true;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }


        //public bool CanExecute(object parameter)
        //{
        //    if (this.m_CanExecute == null)
        //        return true;
        //    if (parameter == null)
        //        return this.m_CanExecute();
        //    return this.m_CanExecute();
        //}
    }
}


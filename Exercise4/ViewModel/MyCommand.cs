﻿using System;
using System.Windows.Input;

namespace ViewModel
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public MyCommand(Action execute) : this(execute, null) { }
        public MyCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}


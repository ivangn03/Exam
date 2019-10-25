﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exam.Infrastucture
{
    class RelayCommand : ICommand
    {
        readonly Action<object> action;
        readonly Predicate<object> predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            this.predicate = predicate;
            this.action = action;
        }

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

        public bool CanExecute(object parameter)
        {
            return predicate == null ? true : predicate(parameter);
        }



        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}

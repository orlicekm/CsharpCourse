﻿using System;
using System.Windows.Input;
using Sample.App.ViewModels;

namespace Sample.App.Commands
{
    public class SendRightTextCommand: ICommand
    {
        private readonly MainViewModel mainViewModel;

        public SendRightTextCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainViewModel.RightText = parameter as string;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
}
}
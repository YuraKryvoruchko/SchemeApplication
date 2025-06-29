﻿using SchemeApplication.Infrastructure.Commands.Base;

namespace SchemeApplication.Infrastructure.Commands
{
    /// <summary>
    /// Клас команди, що наслідується від Command та надає зручний спосіб задання методів виконання та перевірки
    /// </summary>
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool>? _canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool>? canExecute = null) 
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public override void Execute(object? parameter) 
        {
            _execute(parameter);
        }
    }
}

using System.Windows.Input;

namespace SchemeApplication.Infrastructure.Commands.Base
{
    /// <summary>
    /// Абстрактний клас, який надає інтерфейс для взаємодіями з командою 
    /// та подію, що повідомляє про зміну можливості виконання команд 
    /// </summary>
    internal abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);
    }
}

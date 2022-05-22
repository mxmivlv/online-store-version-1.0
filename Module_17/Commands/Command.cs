using System;
using System.Windows.Input;

namespace Module_17.Commands
{
    internal class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<object> excute;
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Excute">Команда для выполнения</param>
        /// <param name="CanExecute">Условие для выполнение</param>
        public Command(Action<object> Excute, Func<object, bool> CanExecute = null)
        {
            excute = Excute;
            canExecute = CanExecute;
        }

        /// <summary>
        /// Функция для выполнение команды
        /// </summary>
        public void Execute(object? parameter) => excute(parameter);

        /// <summary>
        /// Функция возвращающее условие для выполнение команды
        /// </summary>
        public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;       
    }
}

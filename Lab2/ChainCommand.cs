using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2
{
    public class ChainCommand : BaseCommand
    {
        private List<(ICommand, object)> _commandsWithArgs = new List<(ICommand, object)>();
        public int Count => _commandsWithArgs.Count;

        public void AddNext(ICommand command, object parameter)
        {
            _commandsWithArgs.Add((command, parameter));
        }

        public override bool CanExecute(object parameter)
        {
            foreach (var (cmd, arg) in _commandsWithArgs)
            {
                if (!cmd.CanExecute(arg))
                    return false;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            foreach (var (cmd, arg) in _commandsWithArgs)
            {
                cmd.Execute(arg);
            }
        }
    }
}

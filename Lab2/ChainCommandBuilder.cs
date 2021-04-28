using Lab2.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2
{
    public class ChainCommandBuilder : IChainCommandBuilder
    {
        private int _maxCommandsCount;

        private ChainCommand _chainCommand = null;
        public ICommand Result => _chainCommand ?? new ChainCommand();

        public int CommandsCount => _chainCommand?.Count ?? 0;

        public ChainCommandBuilder(int maxCommandsCount = int.MaxValue)
        {
            _maxCommandsCount = maxCommandsCount;
        }

        public bool CanAddNext(ICommand command, object parameter)
        {
            if (_chainCommand is not null)
                return _chainCommand.Count < _maxCommandsCount;
            else
                return _maxCommandsCount > 0;
        }

        public void AddNext(ICommand command, object parameter)
        {
            if (_chainCommand is null)
                _chainCommand = new ChainCommand();

            _chainCommand.AddNext(command, parameter);
        }

        public void Reset()
        {
            _chainCommand = null;
        }
    }
}

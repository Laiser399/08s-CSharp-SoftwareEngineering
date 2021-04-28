using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2.Abstractions
{
    public interface IChainCommandBuilder
    {
        ICommand Result { get; }
        int CommandsCount { get; }

        bool CanAddNext(ICommand command, object parameter);
        void AddNext(ICommand command, object parameter);
        void Reset();
    }
}

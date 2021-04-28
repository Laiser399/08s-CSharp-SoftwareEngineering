using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2.SpecialFigure.Commands.Abstractions
{
    public interface IFigureCommand : ICommand
    {
        string CommandName { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands.Abstractions
{
    public interface IFigureCommand : ISimpleCommand
    {
        string CommandName { get; }
    }
}

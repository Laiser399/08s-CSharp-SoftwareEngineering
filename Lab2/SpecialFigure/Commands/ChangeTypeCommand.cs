using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeTypeCommand : IFigureCommand
    {
        public string CommandName => "ChangeFigureType";

        public IFigure Figure { get; private set; }

        public ChangeTypeCommand(IFigure figure)
        {
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (arg is FigureType figureType)
                Figure.FigureType = figureType;
        }
    }
}

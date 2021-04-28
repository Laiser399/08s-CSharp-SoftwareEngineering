using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeTypeCommand : BaseCommand, IFigureCommand
    {
        public string CommandName => "ChangeFigureType";

        public IFigure Figure { get; private set; }

        public ChangeTypeCommand(IFigure figure)
        {
            Figure = figure;
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is FigureType;
        }

        public override void Execute(object parameter)
        {
            if (parameter is FigureType figureType)
                Figure.FigureType = figureType;
        }
    }
}

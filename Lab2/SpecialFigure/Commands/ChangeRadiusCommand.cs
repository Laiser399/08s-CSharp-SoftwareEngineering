using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeRadiusCommand : BaseCommand, IFigureCommand
    {
        public string CommandName => "ChangeRadius";

        public IFigure Figure { get; private set; }

        public ChangeRadiusCommand(IFigure figure)
        {
            Figure = figure;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is double radius)
                return radius >= 1 && radius <= 100;
            else
                return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is double radius)
                Figure.FigureRadius = radius;
        }
    }
}

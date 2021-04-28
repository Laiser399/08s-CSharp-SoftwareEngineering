using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeBorderThicknessCommand : BaseCommand, IFigureCommand
    {
        public string CommandName => "ChangeBorderThickness";

        public IFigure Figure { get; private set; }

        public ChangeBorderThicknessCommand(IFigure figure)
        {
            Figure = figure;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is double thickness)
                return thickness >= 1 && thickness <= 100;
            else
                return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is double thickness)
                Figure.BorderThickness = thickness;
        }
    }
}

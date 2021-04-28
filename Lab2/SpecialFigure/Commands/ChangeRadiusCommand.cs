using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeRadiusCommand : IFigureCommand
    {
        public string CommandName => "ChangeRadius";

        public IFigure Figure { get; private set; }

        public ChangeRadiusCommand(IFigure figure)
        {
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (arg is double radius)
                Figure.FigureRadius = radius;
        }
    }
}

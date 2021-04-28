using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeBorderThicknessCommand : IFigureCommand
    {
        public string CommandName => "ChangeBorderThickness";

        public IFigure Figure { get; private set; }

        public ChangeBorderThicknessCommand(IFigure figure)
        {
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (arg is double thickness)
                Figure.BorderThickness = thickness;
        }
    }
}

using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangePenColorCommand : IFigureCommand
    {
        public string CommandName => "ChangePenColor";

        public IFigure Figure { get; private set; }

        public ChangePenColorCommand(IFigure figure)
        {
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (arg is Color color)
                Figure.PenColor = color;
        }
    }
}

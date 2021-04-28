using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeBrushColorCommand : IFigureCommand
    {
        public string CommandName => "ChangeBrushColor";

        public IFigure Figure { get; private set; }

        public ChangeBrushColorCommand(IFigure figure)
        {
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (arg is Color color)
                Figure.BrushColor = color;
        }
    }
}

using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2.SpecialFigure.Commands
{
    public class ChangeBrushColorCommand : BaseCommand, IFigureCommand
    {
        public string CommandName => "ChangeBrushColor";

        public IFigure Figure { get; private set; }

        public ChangeBrushColorCommand(IFigure figure)
        {
            Figure = figure;
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is Color;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Color color)
                Figure.BrushColor = color;
        }
    }
}

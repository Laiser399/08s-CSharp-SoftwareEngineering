using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2.SpecialFigure
{
    public interface IFigure
    {
        FigureType FigureType { get; set; }
        double FigureRadius { get; set; }
        Color PenColor { get; set; }
        Color BrushColor { get; set; }
        double BorderThickness { get; set; }

        IFigureSnapshot MakeSnapshot()
        {
            return new Snapshot(
                this,
                FigureType,
                FigureRadius,
                PenColor,
                BrushColor,
                BorderThickness
            );
        }

        // Nested
        private record Snapshot(
            IFigure SpecialFigure,
            FigureType FigureType,
            double FigureRadius,
            Color PenColor,
            Color BrushColor,
            double BorderThickness) : IFigureSnapshot
        {
            public DateTime DateTime { get; init; } = DateTime.Now;

            public void Restore()
            {
                SpecialFigure.FigureType = FigureType;
                SpecialFigure.FigureRadius = FigureRadius;
                SpecialFigure.PenColor = PenColor;
                SpecialFigure.BrushColor = BrushColor;
                SpecialFigure.BorderThickness = BorderThickness;
            }
        }
    }
}

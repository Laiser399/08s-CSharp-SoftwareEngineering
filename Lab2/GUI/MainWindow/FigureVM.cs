using Lab2.SpecialFigure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2.GUI
{
    public class FigureVM : BaseViewModel, IFigure
    {
        #region Bindings

        private FigureType _figureType;
        public FigureType FigureType
        {
            get => _figureType;
            set
            {
                _figureType = value;
                NotifyPropChanged(nameof(FigureType));
            }
        }

        private double _figureRadius = 5;
        public double FigureRadius
        {
            get => _figureRadius;
            set
            {
                _figureRadius = value;
                NotifyPropChanged(nameof(FigureRadius));
            }
        }

        private Color _penColor = Colors.Black;
        public Color PenColor
        {
            get => _penColor;
            set
            {
                _penColor = value;
                NotifyPropChanged(nameof(PenColor));
            }
        }

        private Color _brushColor = Colors.Transparent;
        public Color BrushColor
        {
            get => _brushColor;
            set
            {
                _brushColor = value;
                NotifyPropChanged(nameof(BrushColor));
            }
        }

        private double _borderThickness = 1;
        public double BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                NotifyPropChanged(nameof(BorderThickness));
            }
        }

        #endregion


    }
}

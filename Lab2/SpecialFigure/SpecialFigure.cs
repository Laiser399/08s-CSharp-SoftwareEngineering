using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Shapes;
using Lab2.Ex;

namespace Lab2.SpecialFigure
{
    public class SpecialFigure : Canvas, IFigure
    {
        #region DependencyProperties

        public FigureType FigureType
        {
            get { return (FigureType)GetValue(FigureTypeProperty); }
            set { SetValue(FigureTypeProperty, value); }
        }

        public static readonly DependencyProperty FigureTypeProperty =
            DependencyProperty.Register("FigureType", typeof(FigureType), typeof(SpecialFigure), 
                new FrameworkPropertyMetadata(FigureType.Circle) { AffectsRender = true });


        public double FigureRadius
        {
            get { return (double)GetValue(FigureRadiusProperty); }
            set { SetValue(FigureRadiusProperty, value); }
        }

        public static readonly DependencyProperty FigureRadiusProperty =
            DependencyProperty.Register("FigureRadius", typeof(double), typeof(SpecialFigure), 
                new FrameworkPropertyMetadata(30d) { AffectsRender = true });


        public Color PenColor
        {
            get { return (Color)GetValue(PenColorProperty); }
            set { SetValue(PenColorProperty, value); }
        }

        public static readonly DependencyProperty PenColorProperty =
            DependencyProperty.Register("PenColor", typeof(Color), typeof(SpecialFigure), 
                new FrameworkPropertyMetadata(Colors.Black) { AffectsRender = true });


        public Color BrushColor
        {
            get { return (Color)GetValue(BrushColorProperty); }
            set { SetValue(BrushColorProperty, value); }
        }

        public static readonly DependencyProperty BrushColorProperty =
            DependencyProperty.Register("BrushColor", typeof(Color), typeof(SpecialFigure), 
                new FrameworkPropertyMetadata(Colors.Transparent) { AffectsRender = true });


        public double BorderThickness
        {
            get { return (double)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(double), typeof(SpecialFigure), 
                new FrameworkPropertyMetadata(1d) { AffectsRender = true });

        #endregion

        private const bool _isStroked = true;
        private const bool _isSmoothJoin = false;

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            Point center = new Point(ActualWidth / 2, ActualHeight / 2);

            Brush brush = new SolidColorBrush(BrushColor);
            Pen pen = new Pen(new SolidColorBrush(PenColor), BorderThickness);

            switch (FigureType)
            {
                case FigureType.Circle:
                    DrawCircle(dc, center, brush, pen);
                    break;
                case FigureType.Triangle:
                    DrawRegularPolygon(dc, center, brush, pen, 3);
                    break;
                case FigureType.Square:
                    DrawRegularPolygon(dc, center, brush, pen, 4, 45);
                    break;
                case FigureType.Pentagon:
                    DrawRegularPolygon(dc, center, brush, pen, 5);
                    break;
                case FigureType.Hexagon:
                    DrawRegularPolygon(dc, center, brush, pen, 6);
                    break;
            }
        }

        private void DrawCircle(DrawingContext dc, Point center, Brush brush, Pen pen)
        {
            dc.DrawEllipse(brush, pen, center, FigureRadius, FigureRadius);
        }

        private void DrawRegularPolygon(DrawingContext dc, Point center, Brush brush, Pen pen, int anglesCount,
            double startAngleDeg = 0)
        {
            double angle = 360d / anglesCount;

            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext context = streamGeometry.Open())
            {
                Point next = new Point(center.X, center.Y - FigureRadius);
                next = next.Rotate(center, startAngleDeg);

                context.BeginFigure(next, true, true);
                for (int i = 0; i < anglesCount - 1; i++)
                {
                    next = next.Rotate(center, angle);
                    context.LineTo(next, _isStroked, _isSmoothJoin);
                }
            }

            dc.DrawGeometry(brush, pen, streamGeometry);
        }

    }
}

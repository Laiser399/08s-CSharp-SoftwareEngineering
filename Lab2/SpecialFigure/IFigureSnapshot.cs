using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure
{
    public interface IFigureSnapshot
    {
        DateTime DateTime { get; }
        IFigure SpecialFigure { get; }
        void Restore();
    }
}

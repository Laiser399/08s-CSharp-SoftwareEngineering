using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum Certificate80PLUS
    {
        White,
        Gold,
        Titanium
    }

    interface IPowerSupply
    {
        int PowerW { get; }
        Certificate80PLUS Certificate80PLUS { get; }
    }
}

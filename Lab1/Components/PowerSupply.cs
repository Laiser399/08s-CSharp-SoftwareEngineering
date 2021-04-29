﻿using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Components
{
    record PowerSupply(int PowerW, Certificate80PLUS Certificate80PLUS) : IPowerSupply
    {
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulationProperty;
internal class HumingBeing
{
    public string FullName { get; set; }

    public string Address { private get; set; }
}

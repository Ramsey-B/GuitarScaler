using Scaler.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Core.Models
{
    public class Scale
    {
        public ScaleName Name { get; set; }
        public int[] Intervals { get; set; }
        public string[] TriadeQualities { get; set; }
    }
}

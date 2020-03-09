using Scaler.Core.Enum;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Repositories
{
    public class ScaleRepository : IScaleRepository
    {
        private readonly Dictionary<Scale, int[]> scales = new Dictionary<Scale, int[]>()
        {
            { Scale.Major, new int[] { 2, 2, 1, 2, 2, 2, 1 } },
            { Scale.minor, new int[] { 2, 1, 2, 2, 1, 2, 2 } },
            { Scale.pentatonic, new int[] { 3, 2, 2, 3, 2 } }
        };

        public int[] GetIntervals(Scale scale)
        {
            return scales[scale];
        }
    }
}

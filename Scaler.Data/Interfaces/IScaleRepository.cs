using Scaler.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Interfaces
{
    public interface IScaleRepository
    {
        int[] GetIntervals(Scale scale);
    }
}

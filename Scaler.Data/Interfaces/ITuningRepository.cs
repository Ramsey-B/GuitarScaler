using Scaler.Core.Enum;
using Scaler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Interfaces
{
    public interface ITuningRepository
    {
        IEnumerable<NeckString> GetTuning(Tuning tuning);
    }
}

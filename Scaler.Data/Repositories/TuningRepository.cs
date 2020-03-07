using Scaler.Core.Enum;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Repositories
{
    public class TuningRepository : ITuningRepository
    {
        private readonly IEnumerable<NeckString> EStandardTuning = new List<NeckString>()
        {
            new NeckString(6, "E"),
            new NeckString(5, "A"),
            new NeckString(4, "D"),
            new NeckString(3, "G"),
            new NeckString(2, "B"),
            new NeckString(1, "E"),
        };

        public IEnumerable<NeckString> GetTuning(Tuning tuning)
        {
            switch (tuning)
            {
                case Tuning.EStandard:
                default:
                    return EStandardTuning;
            }
        }
    }
}

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
            new NeckString(1, "E"),
            new NeckString(2, "A"),
            new NeckString(3, "D"),
            new NeckString(4, "G"),
            new NeckString(5, "B"),
            new NeckString(6, "E"),
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

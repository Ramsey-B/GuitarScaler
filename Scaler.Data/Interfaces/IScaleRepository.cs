using Scaler.Core.Enum;
using Scaler.Core.Models;
using System.Collections.Generic;

namespace Scaler.Data.Interfaces
{
    public interface IScaleRepository
    {
        IEnumerable<Note> GetNotesOfScale(string key, ScaleName scale);
        Scale Get(ScaleName scaleName);
    }
}

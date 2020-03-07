using Scaler.Core.Enum;
using Scaler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Business.Interfaces
{
    public interface INeckService
    {
        IEnumerable<NeckString> GetAllNotesOfNeck(Tuning tuning);
        NeckString GetAllNotesOfString(NeckString root);
    }
}

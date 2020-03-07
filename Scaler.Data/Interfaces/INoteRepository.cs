using Scaler.Core.DataStructures;
using Scaler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Interfaces
{
    public interface INoteRepository
    {
        CyclicalList<Note> GetAll();
        Note Get(string name);
    }
}

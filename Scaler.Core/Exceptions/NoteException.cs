using Scaler.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Core.Exceptions
{
    [Serializable]
    public class NoteException : Exception, IScalerException
    {
        public NoteException(string key) : base(key)
        {
            OutputMessageValue = key;
        }

        public string OutputMessageValue { get; set; }
    }
}

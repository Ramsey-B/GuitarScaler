using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Business.Interfaces
{
    public interface IExceptionHandler
    {
        string GenerateUserFriendlyMessage(Exception exception);
    }
}

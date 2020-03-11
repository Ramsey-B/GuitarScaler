using Scaler.Business.Interfaces;
using Scaler.Core.Exceptions;
using System;

namespace Scaler.Business.Handlers
{
    public sealed class ExceptionHandler : IExceptionHandler
    {
        public string GenerateUserFriendlyMessage(Exception exception)
        {
            switch (exception)
            {
                case NoteException noteEx:
                    return $"'{noteEx.OutputMessageValue}' is note a valid Note. Please try again!";
                default:
                    return "An unexpected Error occured. Please try again later!";
            }
        }
    }
}

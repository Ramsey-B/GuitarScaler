using Scaler.Business.Interfaces;

namespace Scaler.Business.Services
{
    public class ChordService : IChordService
    {
        public string GetNotes(string chord)
        {
            return $"This is the chord you entered {chord}";
        }
    }
}

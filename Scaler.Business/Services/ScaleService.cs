using Scaler.Business.Interfaces;
using Scaler.Core.Enum;
using Scaler.Core.Exceptions;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scaler.Business.Services
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly INoteRepository _noteRepository;
        private readonly INeckService _neckService;

        public ScaleService(IScaleRepository scaleRepository, INoteRepository noteRepository, INeckService neckService)
        {
            _scaleRepository = scaleRepository;
            _noteRepository = noteRepository;
            _neckService = neckService;
        }

        public IEnumerable<NeckString> AddScale(string key, ScaleName scale, Tuning tuning)
        {
            key = key?.ToUpper();
            ValidateNoteExists(key);
            var scaleNotes = _scaleRepository.GetNotesOfScale(key, scale);
            var neckStrings = _neckService.GetAllNotesOfNeck(tuning);
            foreach (var neckString in neckStrings)
            {
                foreach (var stringNote in neckString.Notes)
                {
                    if (scaleNotes.Any(n => n.Name == stringNote.Note.Trim()))
                    {
                        stringNote.Set = 1; // Only displays 1 scale at a time.
                    }
                }
            }
            return neckStrings;
        }

        private void ValidateNoteExists(string key)
        {
            var note = _noteRepository.Get(key);
            if (note == null) throw new NoteException(key);
        }
    }
}

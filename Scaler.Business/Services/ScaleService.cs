using Scaler.Business.Interfaces;
using Scaler.Core.Enum;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Business.Services
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly INoteRepository _noteRepository;

        public ScaleService(IScaleRepository scaleRepository, INoteRepository noteRepository)
        {
            _scaleRepository = scaleRepository;
            _noteRepository = noteRepository;
        }

        public IEnumerable<Note> GetNotesOfScale(string key, Scale scale)
        {
            var notes = _noteRepository.GetAll(key);
            var intervals = _scaleRepository.GetIntervals(scale);
            var scaleNotes = new List<Note>();
            var index = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                scaleNotes.Add(notes[index]);
                index += intervals[i];
            }
            return scaleNotes;
        }
    }
}

using Scaler.Business.Interfaces;
using Scaler.Core.Enum;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scaler.Business.Services
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly INeckService _neckService;

        public ScaleService(IScaleRepository scaleRepository, INeckService neckService)
        {
            _scaleRepository = scaleRepository;
            _neckService = neckService;
        }

        public IEnumerable<NeckString> AddScale(string key, ScaleName scale, Tuning tuning)
        {
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
    }
}

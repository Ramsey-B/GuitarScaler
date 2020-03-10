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

        public ScaleService(IScaleRepository scaleRepository)
        {
            _scaleRepository = scaleRepository;
        }

        public IEnumerable<NeckString> AddScale(string key, ScaleName scale, IEnumerable<NeckString> neckStrings)
        {
            var scaleNotes = _scaleRepository.GetNotesOfScale(key, scale);
            foreach (var neckString in neckStrings)
            {
                foreach (var stringNote in neckString.Notes)
                {
                    if (scaleNotes.Any(n => n.Name == stringNote.Note.Trim()))
                    {
                        stringNote.Set = (int)scale; // Only displays 1 scale at a time.
                    }
                }
            }
            return neckStrings;
        }
    }
}

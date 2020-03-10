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
    public class NeckService : INeckService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITuningRepository _tuningRepository;
        private int _fretCount = 22;

        public NeckService(INoteRepository noteRepository, ITuningRepository tuningRepository)
        {
            _noteRepository = noteRepository;
            _tuningRepository = tuningRepository;
        }

        public IEnumerable<NeckString> GetAllNotesOfNeck(Tuning tuning)
        {
            var roots = _tuningRepository.GetTuning(tuning);
            var fretStrings = new List<NeckString>();
            foreach (var root in roots)
            {
                fretStrings.Add(GetAllNotesOfString(root));
            }
            return fretStrings;
        }

        public NeckString GetAllNotesOfString(NeckString root)
        {
            var notes = _noteRepository.GetAll();
            var rootIndex = notes.IndexOf(n => n.Name == root.RootNote);
            var fretNum = 0;
            var notesOfString = new List<NotePosition>();
            for (int i = rootIndex; i < _fretCount + rootIndex && fretNum <= _fretCount; i++)
            {
                var note = notes[i];
                notesOfString.Add(new NotePosition($" {note.Name}", fretNum));
                fretNum++;
            }
            root.Notes = notesOfString;
            return root;
        }
    }
}

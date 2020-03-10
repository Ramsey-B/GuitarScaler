using Scaler.Core.Enum;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Data.Repositories
{
    public class ScaleRepository : IScaleRepository
    {
        public ScaleRepository(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        private readonly Dictionary<ScaleName, Scale> scales = new Dictionary<ScaleName, Scale>()
        {
            { 
                ScaleName.Major, 
                new Scale 
                { 
                    Name = ScaleName.Major,
                    Intervals = new int[] { 2, 2, 1, 2, 2, 2, 1 }, 
                    TriadeQualities = new string[] { "I", "ii", "iii", "IV", "V", "vi", "vii*" } 
                } 
            },
            {
                ScaleName.minor,
                new Scale
                {
                    Name = ScaleName.minor,
                    Intervals = new int[] { 2, 1, 2, 2, 1, 2, 2 },
                    TriadeQualities = new string[] { "i", "ii*", "III+", "iv", "V", "VI", "vii*" }
                }
            },
            {
                ScaleName.pentatonic,
                new Scale
                {
                    Name = ScaleName.pentatonic,
                    Intervals = new int[] { 3, 2, 2, 3, 2 },
                    TriadeQualities = new string[0]
                }
            }
        };
        private readonly INoteRepository _noteRepository;

        public IEnumerable<Note> GetNotesOfScale(string key, ScaleName name)
        {
            var notes = _noteRepository.GetAll(key);
            var intervals = Get(name).Intervals;
            var scaleNotes = new List<Note>();
            var index = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                scaleNotes.Add(notes[index]);
                index += intervals[i];
            }
            return scaleNotes;
        }

        public Scale Get(ScaleName scaleName)
        {
            return scales[scaleName];
        }
    }
}

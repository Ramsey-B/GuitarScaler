using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Core.Models
{
    public class NotePosition
    {
        public string Note { get; set; }
        public int Fret { get; set; }

        public NotePosition()
        {

        }

        public NotePosition(string note, int fret)
        {
            Note = note;
            Fret = fret;
        }
    }
}

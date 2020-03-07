using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Core.Models
{
    public class NeckString
    {
        public int String { get; set; }
        public string RootNote { get; set; }
        public IEnumerable<NotePosition> Notes { get; set; } = new List<NotePosition>();

        public NeckString()
        {

        }

        public NeckString(int stringNum, string rootNote)
        {
            String = stringNum;
            RootNote = rootNote;
        }
    }
}

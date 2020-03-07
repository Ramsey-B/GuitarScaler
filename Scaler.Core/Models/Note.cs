using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Core.Models
{
    public class Note
    {
        public string Name { get; set; }
        public int IntervalToNext { get; set; }
        public string Next { get; set; }

        public Note()
        {

        }

        public Note(string name, int intervalToNext, string next)
        {
            Name = name;
            IntervalToNext = intervalToNext;
            Next = next;
        }
    }
}

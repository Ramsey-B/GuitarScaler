using Scaler.Core.DataStructures;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;

namespace Scaler.Data.Repositories
{
    public class NotesRepository : INoteRepository
    {
        private readonly CyclicalList<Note> notes = new CyclicalList<Note>()
        {
            new Note("A", 1, "A#"),
            new Note("A#", 1, "B"),
            new Note("B", 1, "C"),
            new Note("C", 1, "C#"),
            new Note("C#", 1, "D"),
            new Note("D", 1, "D#"),
            new Note("D#", 1, "E"),
            new Note("E", 1, "F"),
            new Note("F", 1, "F#"),
            new Note("F#", 1, "G"),
            new Note("G", 1, "G#"),
            new Note("G#", 1, "A"),
        };

        public CyclicalList<Note> GetAll()
        {
            return notes;
        }

        public CyclicalList<Note> GetAll(string root)
        {
            var reorderedList = new CyclicalList<Note>();

            var rootNoteIndex = notes.IndexOf(n => n.Name == root);
            for (int i = rootNoteIndex; i < notes.Count + rootNoteIndex; i++)
            {
                var note = notes[i];
                reorderedList.Add(note);
            }

            return reorderedList;
        }

        public Note Get(string name)
        {
            return notes.Find(n => n.Name == name);
        }
    }
}

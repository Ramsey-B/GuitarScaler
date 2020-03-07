using Scaler.Core.DataStructures;
using Scaler.Core.Models;
using Scaler.Data.Interfaces;

namespace Scaler.Data.Repositories
{
    public class NotesRepository : INoteRepository
    {
        private readonly CyclicalList<Note> notes = new CyclicalList<Note>()
        {
            new Note("A", 2, "B"),
            new Note("B", 1, "C"),
            new Note("C", 2, "D"),
            new Note("D", 2, "E"),
            new Note("E", 1, "F"),
            new Note("F", 2, "G"),
            new Note("G", 2, "B")
        };

        public CyclicalList<Note> GetAll()
        {
            return notes;
        }

        public CyclicalList<Note> GetAll(string root)
        {
            var reorderedList = new CyclicalList<Note>();

            var rootNote = Get(root);
            reorderedList.Add(rootNote);
            for (int i = 0; i < notes.Count; i++)
            {

            }

            return reorderedList;
        }

        public Note Get(string name)
        {
            return notes.Find(n => n.Name == name);
        }
    }
}

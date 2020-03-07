using Scaler.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Scaler
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(IChordService chordService)
        {
            _chordService = chordService;
            ChordNotesCommand = new Command<string>(GetChordNotes);
        }

        public ICommand ChordNotesCommand { get; }

        public string DisplayNotes => $"Notes of Chord = {notesOfChord}";

        public event PropertyChangedEventHandler PropertyChanged;

        private string notesOfChord = string.Empty;
        private readonly IChordService _chordService;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GetChordNotes(string chord)
        {
            notesOfChord = _chordService.GetNotes(chord);
            OnPropertyChanged(nameof(DisplayNotes));
        }
    }
}

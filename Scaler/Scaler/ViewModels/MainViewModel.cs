using Scaler.Business.Interfaces;
using Scaler.Core.Models;
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
        private readonly INeckService _neckService;
        private string notesOfSixthString = string.Empty;
        public MainViewModel(INeckService neckService)
        {
            _neckService = neckService;
            GetNeckNotesCommand = new Command(GetNoteOfNeck);
        }

        public ICommand GetNeckNotesCommand { get; }

        public string DisplaySixthString => $"{notesOfSixthString}";

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GetNoteOfNeck()
        {
            var neckStrings = _neckService.GetAllNotesOfNeck(Core.Enum.Tuning.EStandard); // Dont hardcode the tuning...
            foreach (var neckString in neckStrings)
            {
                switch (neckString.String)
                {
                    case 6:
                        notesOfSixthString = NotesToString(neckString);
                        break;
                    default:
                        break;
                }
            }
            OnPropertyChanged(nameof(DisplaySixthString));
        }

        private string NotesToString(NeckString neckString)
        {
            var notesAsString = new StringBuilder();
            foreach (var note in neckString.Notes)
            {
                notesAsString.Append($"{note.Note} |");
            }
            return notesAsString.ToString();
        }
    }
}

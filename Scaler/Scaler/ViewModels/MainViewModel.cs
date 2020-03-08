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
        private DisplayNeck strings = new DisplayNeck 
        { 
            Sixth = string.Empty,
            Fifth = string.Empty
        };
        public MainViewModel(INeckService neckService)
        {
            _neckService = neckService;
            GetNeckNotesCommand = new Command(GetNoteOfNeck);
        }

        public ICommand GetNeckNotesCommand { get; }
        public DisplayNeck DisplayStrings => strings;

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
                        strings.Sixth = NotesToString(neckString);
                        break;
                    case 5:
                        strings.Fifth = NotesToString(neckString);
                        break;
                    case 4:
                        strings.Forth = NotesToString(neckString);
                        break;
                    case 3:
                        strings.Third = NotesToString(neckString);
                        break;
                    case 2:
                        strings.Second = NotesToString(neckString);
                        break;
                    case 1:
                        strings.First = NotesToString(neckString);
                        break;
                    default:
                        break;
                }
            }
            OnPropertyChanged(nameof(DisplayStrings));
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

    public class DisplayNeck
    {
        private int fretCount = 22;
        public string Header => GetHeader();
        public string Sixth { get; set; }
        public string Fifth { get; set; }
        public string Forth { get; set; }
        public string Third { get; set; }
        public string Second { get; set; }
        public string First { get; set; }

        private string GetHeader()
        {
            var header = new StringBuilder("* |");
            for (int i = 0; i < fretCount; i++)
            {
                header.Append($" {i + 1} |");
            }
            return header.ToString();
        }
    }
}

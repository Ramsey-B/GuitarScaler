using Scaler.Business.Interfaces;
using Scaler.Core.Enum;
using Scaler.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Scaler
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INeckService _neckService;
        private readonly IScaleService _scaleService;

        public MainViewModel(INeckService neckService, IScaleService scaleService)
        {
            _neckService = neckService;
            _scaleService = scaleService;
            //GetNeckNotesCommand = new Command(GetNoteOfNeck);
            GetNoteOfNeck();
        }

        public ICommand GetNeckNotesCommand { get; }
        public List<NeckString> DisplayStrings { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SetScale(string key, Scale scale)
        {
            var scaleNotes = _scaleService.GetNotesOfScale(key, scale).ToList();
            foreach (var neckString in DisplayStrings)
            {
                foreach (var stringNote in neckString.Notes)
                {
                    if (scaleNotes.Any(n => n.Name == stringNote.Note.Trim()))
                    {
                        stringNote.Set = 1; // Only displays 1 scale at a time.
                    }
                }
            }
        }

        private void GetNoteOfNeck()
        {
            DisplayStrings = _neckService.GetAllNotesOfNeck(Core.Enum.Tuning.EStandard).ToList(); // Dont hardcode the tuning...

            SetScale("F", Scale.Major);
            OnPropertyChanged(nameof(DisplayStrings));
        }
    }
}

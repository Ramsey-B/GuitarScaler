using Scaler.Business.Interfaces;
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

        public MainViewModel(INeckService neckService)
        {
            _neckService = neckService;
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

        private void GetNoteOfNeck()
        {
            DisplayStrings = _neckService.GetAllNotesOfNeck(Core.Enum.Tuning.EStandard).ToList(); // Dont hardcode the tuning...

            OnPropertyChanged(nameof(DisplayStrings));
        }
    }
}

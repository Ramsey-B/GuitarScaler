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
        public IEnumerable<NeckString> DisplayStrings { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SetScale(string key, ScaleName scale)
        {
            DisplayStrings = _scaleService.AddScale(key, scale, DisplayStrings);
        }

        private void GetNoteOfNeck()
        {
            DisplayStrings = _neckService.GetAllNotesOfNeck(Core.Enum.Tuning.EStandard).ToList(); // Dont hardcode the tuning...

            SetScale("F", ScaleName.Major);
            OnPropertyChanged(nameof(DisplayStrings));
        }
    }
}

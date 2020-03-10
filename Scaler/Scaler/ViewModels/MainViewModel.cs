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
        private ScaleName _selectedScale;
        private string _selectedKey;

        public MainViewModel(INeckService neckService, IScaleService scaleService)
        {
            _neckService = neckService;
            _scaleService = scaleService;
            GetNoteOfNeck();
        }

        public IEnumerable<NeckString> DisplayStrings { get; private set; }
        public ScaleName SelectedScale 
        { 
            get => _selectedScale;
            set 
            {
                _selectedScale = value;
                SetScale();
            } 
        }
        public string SelectedKey 
        { 
            get => _selectedKey;
            set
            {
                _selectedKey = value;
                SetScale();
            }
        }
        public IEnumerable<ScaleName> Scales => Enum.GetValues(typeof(ScaleName)).Cast<ScaleName>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SetScale()
        {
            if (SelectedScale > 0 && !string.IsNullOrWhiteSpace(SelectedKey))
            {
                GetNoteOfNeck();
                DisplayStrings = _scaleService.AddScale(SelectedKey, SelectedScale, DisplayStrings);
                OnPropertyChanged(nameof(DisplayStrings));
            }
        }

        private void GetNoteOfNeck()
        {
            DisplayStrings = _neckService.GetAllNotesOfNeck(Tuning.EStandard); // Dont hardcode the tuning...
            //OnPropertyChanged(nameof(DisplayStrings));
        }
    }
}

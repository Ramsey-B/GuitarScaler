using Scaler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scaler.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NeckGrid : ContentView
    {
        public NeckGrid()
        {
            //BindingContext = this;
            InitializeComponent();
            //BuildColumns();
            //BuildRows();
        }

        public IEnumerable<NeckString> NeckStrings
        {
            get 
            { 
                return (IEnumerable<NeckString>)GetValue(NeckStringsProperty);
            }
            set 
            { 
                SetValue(NeckStringsProperty, value);
                BuildNeck();
            }
        }

        public static readonly BindableProperty NeckStringsProperty =
            BindableProperty.Create(
                nameof(NeckStrings), 
                typeof(IEnumerable<NeckString>), 
                typeof(NeckGrid), 
                new List<NeckString>(), 
                BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    var ctrl = (NeckGrid)b;
                    ctrl.NeckStrings = (IEnumerable<NeckString>)n;
                });

        private void BuildNeck()
        {
            BuildColumns();
            BuildRows();
            AddHeaders();
            FillStrings();
        }

        private void BuildColumns()
        {
            var fretCount = NeckStrings.FirstOrDefault()?.Notes.Count() ?? 0;
            for (int i = 0; i < fretCount; i++)
            {
                neckLayout.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void BuildRows()
        {
            for (int i = 0; i < NeckStrings.Count() + 1; i++)
            {
                neckLayout.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void AddHeaders()
        {
            for (int i = 0; i < neckLayout.ColumnDefinitions.Count; i++)
            {
                var frame = new Frame
                {
                    BorderColor = Color.Black,
                    Padding = 0,
                    Margin = 0
                };
                frame.Content = new Label { Text = $" {i} ", TextColor = Color.Black, FontSize = 16, HorizontalTextAlignment = TextAlignment.Center };
                neckLayout.Children.Add(frame, i, 0);
            }
        }

        private void FillStrings()
        {
            for (int i = 0; i < NeckStrings.Count(); i++)
            {
                var neckString = NeckStrings.ElementAt(i);
                AddNotes(neckString);
            }
        }

        private void AddNotes(NeckString neckString)
        {
            foreach (var note in neckString.Notes)
            {
                var frame = new Frame
                {
                    BorderColor = Color.Black,
                    Padding = 0,
                    Margin = 0
                };
                frame.Content = new Label { Text = $" {note.Note} ", TextColor = Color.Black, FontSize = 16, HorizontalTextAlignment = TextAlignment.Center };
                neckLayout.Children.Add(frame, note.Fret, neckString.String);
            }
        }
    }
}
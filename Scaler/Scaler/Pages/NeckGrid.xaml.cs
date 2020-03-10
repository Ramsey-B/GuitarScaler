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
        private const double fretSpaceConst = 17.817;
        private const double firstFretWidth = 65;
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
            var totalLength = fretSpaceConst * firstFretWidth;
            var fretCount = NeckStrings.FirstOrDefault()?.Notes.Count() ?? 0;
            for (int i = 0; i < fretCount; i++)
            {
                var columnDef = new ColumnDefinition();
                if (i != 0)
                {
                    var columnWidth = Math.Floor(totalLength / fretSpaceConst);
                    columnDef.Width = new GridLength(columnWidth);
                    totalLength -= columnWidth;
                }
                else
                {
                    columnDef.Width = new GridLength(25);
                }

                neckLayout.ColumnDefinitions.Add(columnDef);
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
                frame.Content = new Label { Text = $" {i} ", TextColor = Color.Black, FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
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
                    Margin = 0,
                    BackgroundColor = Color.LightGreen
                };
                var label = new Label { Text = $" {note.Note} ", TextColor = Color.Black, FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
                if (note.Set == 1)
                {
                    
                    label.BackgroundColor = Color.Red;
                }
                frame.Content = label;
                neckLayout.Children.Add(frame, note.Fret, neckString.String);
            }
        }
    }
}
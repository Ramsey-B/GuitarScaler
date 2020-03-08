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
                BuildColumns();
                BuildRows();
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

        private void BuildColumns()
        {
            var fretCount = NeckStrings.FirstOrDefault()?.Notes.Count() ?? 0;
            for (int i = 0; i < fretCount; i++)
            {
                neckLayout.ColumnDefinitions.Add(new ColumnDefinition());
                var label = new Label
                {
                    Text = i == 0 ? "  " : $" {i} ",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                    FontSize = 16
                };
                neckLayout.Children.Add(label, i, 0);
            }
        }

        private void BuildRows()
        {
            for (int i = 0; i < NeckStrings.Count(); i++)
            {
                neckLayout.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}
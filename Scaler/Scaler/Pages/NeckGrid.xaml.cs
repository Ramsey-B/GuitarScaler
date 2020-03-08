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
        private int fretCount = 22;
        private int stringCount = 6;

        public NeckGrid()
        {
            BindingContext = this;
            InitializeComponent();
            //BuildColumns();
            //BuildRows();
        }

        public string NeckNotes
        {
            get 
            { 
                var test = (string)GetValue(NeckNotesProperty);
                return test;
            }
            set 
            { 
                SetValue(NeckNotesProperty, value); 
            }
        }

        public static readonly BindableProperty NeckNotesProperty =
            BindableProperty.Create(nameof(NeckNotes), typeof(string), typeof(NeckGrid), "Default");

        //private void BuildColumns()
        //{
        //    for (int i = 0; i < fretCount + 1; i++)
        //    {
        //        neckLayout.ColumnDefinitions.Add(new ColumnDefinition());
        //        var label = new Label
        //        {
        //            Text = i == 0 ? "  " : $" {i} ",
        //            VerticalOptions = LayoutOptions.Center,
        //            HorizontalOptions = LayoutOptions.Center,
        //            TextDecorations = TextDecorations.Underline,
        //            FontSize = 16
        //        };
        //        neckLayout.Children.Add(label, i, 0);
        //    }
        //}

        //private void BuildRows()
        //{
        //    for (int i = 0; i < stringCount; i++)
        //    {
        //        neckLayout.RowDefinitions.Add(new RowDefinition());
        //    }
        //}
    }
}
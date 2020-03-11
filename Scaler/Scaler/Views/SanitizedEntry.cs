using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Scaler.Views
{
    public class SanitizedEntry : Entry
    {
        public string RegexInput { get; set; }

        public SanitizedEntry()
        {

            TextChanged += ExecuteRegex;
        }

        private void ExecuteRegex(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var value = entry?.Text;

            if (!string.IsNullOrWhiteSpace(value))
            {
                entry.Text = Regex.Replace(value, RegexInput, string.Empty);
            }
        }
    }
}
